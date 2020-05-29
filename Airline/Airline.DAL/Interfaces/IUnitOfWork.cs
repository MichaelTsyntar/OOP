using Airline.DAL.Interfaces.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IPassengerRepository PassengerRepository { get; }
        IFlightScheduleRepository FlightScheduleRepository { get; }
        IFlightRepository FlightRepository { get; }
    }
}
