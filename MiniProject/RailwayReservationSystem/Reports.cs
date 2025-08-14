using System;
using System.Data;
using System.Data.SqlClient;

public class Reports
{
    private DatabaseManager dbManager = new DatabaseManager();

    public DataTable GetTicketReport(DateTime? fromDate = null, DateTime? toDate = null)
    {
        string query = @"SELECT r.BookingId, c.CustName, t.TrainName, 
                        r.TravelDate, r.Class, r.TotalCost, r.BookingDate, r.Status, r.TicketCount
                        FROM Reservations r
                        JOIN Customers c ON r.CustId = c.CustId
                        JOIN Trains t ON r.TrainNo = t.TrainNo";

        SqlParameter[] parameters = null;

        if (fromDate.HasValue && toDate.HasValue)
        {
            query += " WHERE r.BookingDate BETWEEN @FromDate AND @ToDate";
            parameters = new SqlParameter[] {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };
        }

        query += " ORDER BY r.BookingDate DESC";
        return dbManager.ExecuteQuery(query, parameters);
    }

    public DataTable GetCancellationReport(DateTime? fromDate = null, DateTime? toDate = null)
    {
        string query = @"SELECT cn.CancelId, r.BookingId, c.CustName, t.TrainName,
                        cn.CancelDate as 'CancellationDate',
                        cn.RefundAmount, (r.TotalCost - cn.RefundAmount) AS CancellationCharges,
                        r.status as 'OriginalStatus'
                        FROM Cancellations cn
                        JOIN Reservations r ON cn.BookingId = r.BookingId
                        JOIN Customers c ON r.CustId = c.CustId
                        JOIN Trains t ON r.TrainNo = t.TrainNo";

        SqlParameter[] parameters = null;

        if (fromDate.HasValue && toDate.HasValue)
        {
            query += " WHERE cn.CancelDate BETWEEN @FromDate AND @ToDate";
            parameters = new SqlParameter[] {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };
        }

        query += " ORDER BY cn.CancelDate DESC";
        return dbManager.ExecuteQuery(query, parameters);
    }
}
