using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.BLL.DTOs
{
   public class FlightScheduleDTO
    {
        public int Id { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
    }
}
