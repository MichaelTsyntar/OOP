using Airline.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Airline.DAL.Entities
{
    public partial class FlightSchedule : IEntity
    {  
        public int Id { set; get; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }

       
    }
}
