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

    public class FlightScheduleRepository : GenericRepository<FlightSchedule>, IFlightScheduleRepository
    {
        public FlightScheduleRepository(AirlineContext db)
            : base(db)
        {
        }


        public async Task<IEnumerable<FlightSchedule>> GetDateFlightSchedule(string DepartureDate)
        {
            return await db.FlightSchedule.Where(e => e.DepartureDate == DepartureDate).ToListAsync();
        }
    }
}

