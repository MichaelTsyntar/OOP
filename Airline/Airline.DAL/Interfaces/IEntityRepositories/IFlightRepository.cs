using Airline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airline.DAL.Interfaces.IEntityRepositories
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetAirlinesFlight(string Airlines);
    }
}
