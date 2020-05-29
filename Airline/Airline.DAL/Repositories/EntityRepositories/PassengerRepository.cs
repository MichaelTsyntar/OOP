using Airline.DAL.DBContext;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces.IEntityRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.DAL.Repositories.EntityRepositories
{
    public class PassengerRepository : GenericRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(AirlineContext db)
            : base(db)
        {
        }

     
        public async Task<IEnumerable<Passenger>> GetNamePassengers(string Name)
        {
            return await db.Passenger.Where(e => e.Name == Name).ToListAsync();
        }
    }
}
