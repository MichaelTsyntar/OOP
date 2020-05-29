using Airline.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Airline.BLL.Interfaces.IServices
{
  public interface IPassengerService
    {
        Task<IEnumerable<PassengerDTO>> GetAllPassengerAsync();

        Task<PassengerDTO> GetPassengerAsync(int Id);
        Task UpdatePassengerAsync(PassengerDTO passengerDTO);
        Task AddPassengerAsync(PassengerDTO passengerDTO);
        Task DeletePassengerAsync(PassengerDTO passengerDTO);
        Task<IEnumerable<PassengerDTO>> GetNamePassengers(string Name);



    }
}
