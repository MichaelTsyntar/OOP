using Airline.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airline.BLL.Interfaces.IServices
{
    public interface IFlightScheduleService
    {
        Task<IEnumerable<FlightScheduleDTO>> GetAllFlightScheduleAsync();
        Task<FlightScheduleDTO> GetFlightScheduleAsync(int Id);
        Task UpdateFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO);
        Task AddFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO);
        Task DeleteFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO);
        Task<IEnumerable<FlightScheduleDTO>> GetDateFlightSchedule(string DepartureDate);

    }
}
