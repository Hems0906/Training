using System;
using System.Data;
using System.Data.SqlClient;

public class Train
{
    private DatabaseManager dbManager = new DatabaseManager();

    public DataTable Trains()
    {
        string query = @"SELECT TrainNo, TrainName, Source, Destination, 
                        AvailabilityAC, Availability2AC, Availability3AC, AvailabilitySleeper,
                        CostAC, Cost2AC, Cost3AC, CostSleeper,
                        CONVERT(VARCHAR(8), DepartureTime, 108) AS DepartureTime,
                        CONVERT(VARCHAR(8), ArrivalTime, 108) AS ArrivalTime
                        FROM Trains
                        ORDER BY TrainNo";

        return dbManager.ExecuteQuery(query);
    }

    public int AddTrain(int trainNo, string trainName, string source, string destination, 
                     int availabilityAC, int availability2AC, int availability3AC, int availabilitySleeper,
                     decimal costAC, decimal cost2AC, decimal cost3AC, decimal costSleeper,
                     TimeSpan departureTime, TimeSpan arrivalTime)
    {
        try
        {
            string query = @"INSERT INTO Trains 
                       (TrainNo, TrainName, Source, Destination,
                        AvailabilityAC, Availability2AC, Availability3AC, AvailabilitySleeper,
                        CostAC, Cost2AC, Cost3AC, CostSleeper,
                        DepartureTime, ArrivalTime) 
                       VALUES 
                       (@TrainNo, @TrainName, @Source, @Destination,
                        @AvailabilityAC, @Availability2AC, @Availability3AC, @AvailabilitySleeper,
                        @CostAC, @Cost2AC, @Cost3AC, @CostSleeper,
                        @DepartureTime, @ArrivalTime)";

            SqlParameter[] parameters = {
            new SqlParameter("@TrainNo", trainNo),
            new SqlParameter("@TrainName", trainName),
            new SqlParameter("@Source", source),
            new SqlParameter("@Destination", destination),
            new SqlParameter("@AvailabilityAC", availabilityAC),
            new SqlParameter("@Availability2AC", availability2AC),
            new SqlParameter("@Availability3AC", availability3AC),
            new SqlParameter("@AvailabilitySleeper", availabilitySleeper),
            new SqlParameter("@CostAC", costAC),
            new SqlParameter("@Cost2AC", cost2AC),
            new SqlParameter("@Cost3AC", cost3AC),
            new SqlParameter("@CostSleeper", costSleeper),
            new SqlParameter("@DepartureTime", departureTime),
            new SqlParameter("@ArrivalTime", arrivalTime)
        };

            return dbManager.ExecuteNonQuery(query, parameters);
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine($"SQL Error: {sqlEx.Message}");
            return -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
            return -1;
        }
    }
}
