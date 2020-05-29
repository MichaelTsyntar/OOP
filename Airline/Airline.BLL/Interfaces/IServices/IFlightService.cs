using Airline.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airline.BLL.Interfaces.IServices
{
   public interface IFlightService
    {
        Task<IEnumerable<FlightDTO>> GetAllFlightAsync();
        Task<FlightDTO> GetFlightAsync(int Id);
        Task UpdateFlightAsync(FlightDTO flightDTO);
        Task AddFlightAsync(FlightDTO flightDTO);
        Task DeleteFlightAsync(FlightDTO flightDTO);
        Task<IEnumerable<FlightDTO>> GetAirlinesFlight(string Airlines);
    }
}
