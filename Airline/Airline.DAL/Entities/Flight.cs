using Airline.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Airline.DAL.Entities
{
    public partial class Flight:IEntity
    {
        public int Id { get; set; }
        public int FlightSheduleId { get; set; }
        public int PassengerId { get; set; }
        public string Froms { get; set; }
        public string Wheres { get; set; }
        public string Airlines { get; set; }
        
    }
}
