using AirlineUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirlineUI.Services
{
    public class FlightScheduleService
    {
        public HttpClient _httpClient;

        public FlightScheduleService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<FlightScheduleViewModel>> GetAllFlightScheduleAsync()
        {
            var response = await _httpClient.GetAsync("api/flightSchedule");
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<FlightScheduleViewModel>>(responseContent);
        }
        //Task<IEnumerable<FlightScheduleDTO>> GetAllFlightScheduleAsync();
        //Task<FlightScheduleDTO> GetFlightScheduleAsync(int Id);
        //Task UpdateFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO);
        //Task AddFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO);
        //Task DeleteFlightScheduleAsync(FlightScheduleDTO flightScheduleDTO);
        //Task<IEnumerable<FlightScheduleDTO>> GetDateFlightSchedule(string DepartureDate);
    }
}
