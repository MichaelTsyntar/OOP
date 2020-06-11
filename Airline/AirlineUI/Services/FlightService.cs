using AirlineUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirlineUI.Services
{
    public class FlightService
    {
        public HttpClient _httpClient;

        public FlightService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<FlightViewModel>> GetAllFlightAsync()
        {
            var response = await _httpClient.GetAsync("api/flight");
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<FlightViewModel>>(responseContent);
        }
        //Task<IEnumerable<FlightDTO>> GetAllFlightAsync();
        //Task<FlightDTO> GetFlightAsync(int Id);
        //Task UpdateFlightAsync(FlightDTO flightDTO);
        //Task AddFlightAsync(FlightDTO flightDTO);
        //Task DeleteFlightAsync(FlightDTO flightDTO);
        //Task<IEnumerable<FlightDTO>> GetAirlinesFlight(string Airlines);
    }
}
