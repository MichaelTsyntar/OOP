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
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        public FlightRepository(AirlineContext db)
            : base(db)
        {
        }


        public async Task<IEnumerable<Flight>> GetAirlinesFlight(string Airlines)
        {
            return await db.Flight.Where(e => e.Airlines == Airlines).ToListAsync();
        }
    }
}
