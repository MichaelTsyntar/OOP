using AirlineUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirlineUI.Services
{
    public class PassengerService
    {
        public HttpClient _httpClient;

        public PassengerService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<PassengerViewModel>> GetAllPassengerAsync()
        {
            var response = await _httpClient.GetAsync("api/passenger");
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<PassengerViewModel>>(responseContent);
        }
        public async Task<HttpResponseMessage> AddPassengerAsync(PassengerViewModel passenger)
        {
            return await _httpClient.PostAsync("api/Passenger", GetStringContentFromObject(passenger));
        }

        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }


        //Task<IEnumerable<PassengerDTO>> GetAllPassengerAsync();

        //Task<PassengerDTO> GetPassengerAsync(int Id);
        //Task UpdatePassengerAsync(PassengerDTO passengerDTO);
        //Task AddPassengerAsync(PassengerDTO passengerDTO);
        //Task DeletePassengerAsync(PassengerDTO passengerDTO);
        //Task<IEnumerable<PassengerDTO>> GetNamePassengers(string Name);;
    }
}
