using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.BLL.DTOs
{
  public  class FlightDTO
    {
        public int Id { get; set; }
        public string Froms { get; set; }
        public string Wheres { get; set; }
        public string Airlines { get; set; }
    }
}
