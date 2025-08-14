select * from trains
drop table trains
CREATE TABLE trains (
    TrainNo INT PRIMARY KEY, 
    TrainName NVARCHAR(100) NOT NULL,
    Source NVARCHAR(100) NOT NULL,
    Destination NVARCHAR(100) NOT NULL,
    AvailabilityAC INT NOT NULL,
    Availability2AC INT NOT NULL,
    Availability3AC INT NOT NULL,
    AvailabilitySleeper INT NOT NULL,
    CostAC DECIMAL(10,2) NOT NULL,
    Cost2AC DECIMAL(10,2) NOT NULL,
    Cost3AC DECIMAL(10,2) NOT NULL,
    CostSleeper DECIMAL(10,2) NOT NULL,
    DepartureTime TIME NOT NULL,
    ArrivalTime TIME NOT NULL
);
