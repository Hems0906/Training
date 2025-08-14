using System;
using System.Data;
using System.Data.SqlClient;

public class Reservation
{
    private DatabaseManager dbManager = new DatabaseManager();

    public DataTable GetCustomerReservations(int custId)
    {
        string query = @"
        SELECT 
            r.BookingId, 
            t.TrainName, 
            r.TravelDate, 
            r.Class, 
            r.TotalCost, 
            r.BookingDate, 
            r.Status, 
            r.TicketCount,
            ISNULL(cn.RefundAmount, 0) AS RefundAmount
        FROM Reservations r
        JOIN Trains t 
            ON r.TrainNo = t.TrainNo
        LEFT JOIN Cancellations cn 
            ON r.BookingId = cn.BookingId
        WHERE r.CustId = @CustId
        ORDER BY r.BookingDate DESC";

        SqlParameter[] parameters = {
        new SqlParameter("@CustId", custId)
    };

        return dbManager.ExecuteQuery(query, parameters);
    }


    public int BookTicket(int custId, int trainNo, DateTime travelDate, string trainClass, int ticketCount)
    {
        // Get availability and cost for selected class
        string trainQuery = "SELECT * FROM Trains WHERE TrainNo = @TrainNo";
        SqlParameter[] trainParams = { new SqlParameter("@TrainNo", trainNo) };
        DataTable trainDetails = dbManager.ExecuteQuery(trainQuery, trainParams);

        if (trainDetails.Rows.Count == 0) return -1;

        string availabilityColumn = "";
        string costColumn = "";

        switch (trainClass.ToUpper())
        {
            case "AC":
                availabilityColumn = "AvailabilityAC";
                costColumn = "CostAC";
                break;
            case "2AC":
                availabilityColumn = "Availability2AC";
                costColumn = "Cost2AC";
                break;
            case "3AC":
                availabilityColumn = "Availability3AC";
                costColumn = "Cost3AC";
                break;
            case "SLEEPER":
                availabilityColumn = "AvailabilitySleeper";
                costColumn = "CostSleeper";
                break;
            default:
                return -1;
        }

        int availability = Convert.ToInt32(trainDetails.Rows[0][availabilityColumn]);
        decimal costPerTicket = Convert.ToDecimal(trainDetails.Rows[0][costColumn]);
        decimal totalCost = costPerTicket * ticketCount;
        string status = "Confirmed";
        decimal paidAmount = totalCost;

        if (ticketCount > availability)
        {
            status = "WaitingList"; 
            paidAmount = totalCost ; 
        }
        else
        {
            // Reduce availability for confirmed bookings
            string updateAvailabilityQuery = $@"
            UPDATE Trains 
            SET {availabilityColumn} = {availabilityColumn} - @TicketCount 
            WHERE TrainNo = @TrainNo";

            dbManager.ExecuteNonQuery(updateAvailabilityQuery, new SqlParameter[] {
                new SqlParameter("@TicketCount", ticketCount),
                new SqlParameter("@TrainNo", trainNo)
            });
        }

        string query = @"INSERT INTO Reservations 
               (CustId, TrainNo, TravelDate, Class, TicketCount, TotalCost, PaidAmount, Status) 
               VALUES 
               (@CustId, @TrainNo, @TravelDate, @Class, @TicketCount, @TotalCost, @PaidAmount, @Status)";

        SqlParameter[] parameters = {
            new SqlParameter("@CustId", custId),
            new SqlParameter("@TrainNo", trainNo),
            new SqlParameter("@TravelDate", travelDate),
            new SqlParameter("@Class", trainClass),
            new SqlParameter("@TicketCount", ticketCount),
            new SqlParameter("@TotalCost", totalCost),
            new SqlParameter("@PaidAmount", paidAmount),
            new SqlParameter("@Status", status)
        };

        return dbManager.ExecuteNonQuery(query, parameters);
    }

    public int CancelTicket(int bookingId, int custId)
    {
        // Fetch reservation
        DataTable reservation = dbManager.ExecuteQuery(
            "SELECT * FROM Reservations WHERE BookingId = @BookingId AND CustId = @CustId",
            new SqlParameter[] {
            new SqlParameter("@BookingId", bookingId),
            new SqlParameter("@CustId", custId)
            });

        if (reservation.Rows.Count == 0) return -1;

        string status = reservation.Rows[0]["Status"].ToString();
        decimal totalCost = Convert.ToDecimal(reservation.Rows[0]["TotalCost"]);
        int ticketCount = Convert.ToInt32(reservation.Rows[0]["TicketCount"]);
        int trainNo = Convert.ToInt32(reservation.Rows[0]["TrainNo"]);
        string trainClass = reservation.Rows[0]["Class"].ToString();
        DateTime travelDate = Convert.ToDateTime(reservation.Rows[0]["TravelDate"]);
        decimal refundAmount = 0;

        string availabilityColumn = null;
        string upperClass = trainClass.ToUpper();

        if (upperClass == "AC")
            availabilityColumn = "AvailabilityAC";
        else if (upperClass == "2AC")
            availabilityColumn = "Availability2AC";
        else if (upperClass == "3AC")
            availabilityColumn = "Availability3AC";
        else if (upperClass == "SLEEPER")
            availabilityColumn = "AvailabilitySleeper";


        if (status == "Confirmed")
        {
            refundAmount = totalCost * 0.5m;

            // Try to promote from waitlist
            bool promoted = PromoteWaitingList(trainNo, trainClass, travelDate, ticketCount);

            if (!promoted && !string.IsNullOrEmpty(availabilityColumn))
            {
                // No waitlist → restore seat count
                string updateSeatsQuery = $@"
                UPDATE Trains 
                SET {availabilityColumn} = {availabilityColumn} + @TicketCount
                WHERE TrainNo = @TrainNo";

                dbManager.ExecuteNonQuery(updateSeatsQuery, new SqlParameter[] {
                new SqlParameter("@TicketCount", ticketCount),
                new SqlParameter("@TrainNo", trainNo)
            });
            }
        }
        else if (status == "WaitingList")
        {
            refundAmount = totalCost * 0.6m;
        }

        // Update reservation status
        dbManager.ExecuteNonQuery(
            "UPDATE Reservations SET Status = 'Cancelled' WHERE BookingId = @BookingId",
            new SqlParameter[] { new SqlParameter("@BookingId", bookingId) }
        );

        // Record cancellation
        dbManager.ExecuteNonQuery(
            @"INSERT INTO Cancellations (BookingId, TicketCount, RefundAmount, CancellationDate) 
          VALUES (@BookingId, @TicketCount, @RefundAmount, GETDATE())",
            new SqlParameter[] {
            new SqlParameter("@BookingId", bookingId),
            new SqlParameter("@TicketCount", ticketCount),
            new SqlParameter("@RefundAmount", refundAmount)
            }
        );

        return 1;
    }

    private bool PromoteWaitingList(int trainNo, string trainClass, DateTime travelDate, int freedSeats)
    {
        
      string availabilityColumn = null;
        string upperClass = trainClass.ToUpper();

        if (upperClass == "AC")
            availabilityColumn = "AvailabilityAC";
        else if (upperClass == "2AC")
            availabilityColumn = "Availability2AC";
        else if (upperClass == "3AC")
            availabilityColumn = "Availability3AC";
        else if (upperClass == "SLEEPER")
            availabilityColumn = "AvailabilitySleeper";


        if (string.IsNullOrEmpty(availabilityColumn)) return false;

        // Fetch next waiting list bookings within available freed seats
        DataTable waitingList = dbManager.ExecuteQuery(
            @"SELECT TOP (@Seats) * FROM Reservations 
          WHERE TrainNo = @TrainNo 
          AND Class = @Class 
          AND TravelDate = @TravelDate 
          AND Status = 'WaitingList'
          ORDER BY BookingId",
            new SqlParameter[] {
            new SqlParameter("@Seats", freedSeats),
            new SqlParameter("@TrainNo", trainNo),
            new SqlParameter("@Class", trainClass),
            new SqlParameter("@TravelDate", travelDate)
            });

        if (waitingList.Rows.Count == 0) return false;

        string updateSeatsQuery = $@"
        UPDATE Trains 
        SET {availabilityColumn} = {availabilityColumn} - @PromotedCount
        WHERE TrainNo = @TrainNo";

        dbManager.ExecuteNonQuery(updateSeatsQuery, new SqlParameter[] {
        new SqlParameter("@PromotedCount", waitingList.Rows.Count),
        new SqlParameter("@TrainNo", trainNo)
    });

        // Promote each waiting list booking
        foreach (DataRow row in waitingList.Rows)
        {
            int bookingId = Convert.ToInt32(row["BookingId"]);
            decimal ticketPrice = Convert.ToDecimal(row["TotalCost"]);

            dbManager.ExecuteNonQuery(
                "UPDATE Reservations SET Status = 'Confirmed', TotalCost = @TotalCost WHERE BookingId = @BookingId",
                new SqlParameter[] {
                new SqlParameter("@BookingId", bookingId),
                new SqlParameter("@TotalCost", ticketPrice)
                }
            );
        }

        return true;
    }

}
