using Airline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airline.DAL.Interfaces.IEntityRepositories
{
    public interface IFlightScheduleRepository : IGenericRepository<FlightSchedule>
    {
        Task<IEnumerable<FlightSchedule>> GetDateFlightSchedule(string DepartureDate);
    }
}
