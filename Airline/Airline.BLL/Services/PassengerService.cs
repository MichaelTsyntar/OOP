using Airline.BLL.DTOs;
using Airline.BLL.Interfaces.IServices;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airline.BLL.Services
{
    public class PassengerService : SetOfFields, IPassengerService
    {
        public PassengerService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task AddPassengerAsync(PassengerDTO passengerDTO)
        {
            var passenger = mapper.Map<Passenger>(passengerDTO);

            await unitOfWork.PassengerRepository.Add(passenger);
        }

        public async Task DeletePassengerAsync(PassengerDTO passengerDTO)
        {
            var passenger = await unitOfWork.PassengerRepository.Get(passengerDTO.Id);

            if (passenger == null)
            {
                throw new Exception("Not found");
            }

            

            await unitOfWork.PassengerRepository.Delete(passenger);
        }

        public async Task<PassengerDTO> GetPassengerAsync(int Id)
        {
            var passenger = await unitOfWork.PassengerRepository.Get(Id);

            if (passenger == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<PassengerDTO>(passenger);
        }

        

        public async Task<IEnumerable<PassengerDTO>> GetAllPassengerAsync()
        {
            var passengers = await unitOfWork.PassengerRepository.GetAll();

            if (passengers == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<PassengerDTO>>(passengers);
        }

        public async Task<IEnumerable<PassengerDTO>> GetNamePassengers(string Name)
        {
            if (Name == null)
            {
                throw new Exception("Author's name is null");
            }

            var passengers = await unitOfWork.PassengerRepository.GetNamePassengers(Name);

            if (passengers == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<PassengerDTO>>(passengers);
        }

        public async Task UpdatePassengerAsync(PassengerDTO passengerDTO)
        {
            var passenger = mapper.Map<Passenger>(passengerDTO);

            await unitOfWork.PassengerRepository.Update(passenger);
        }

       
    }
}
