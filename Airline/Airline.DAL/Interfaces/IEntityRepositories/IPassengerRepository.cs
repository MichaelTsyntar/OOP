using Airline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airline.DAL.Interfaces.IEntityRepositories
{
   public interface IPassengerRepository : IGenericRepository<Passenger>
    {
        Task<IEnumerable<Passenger>> GetNamePassengers(string Name);
    }
}
