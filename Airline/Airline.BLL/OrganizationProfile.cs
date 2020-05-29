using Airline.BLL.DTOs;
using System;
using AutoMapper;
using Airline.DAL.Entities;

namespace Airline.BLL
{
    public class OrganizationProfile:Profile
    {
        public OrganizationProfile()
        {
        
            CreateMap<Passenger, PassengerDTO>()
                .ReverseMap();

            CreateMap<Flight, FlightDTO>()
                .ReverseMap();

            CreateMap<FlightSchedule, FlightScheduleDTO>()
                .ReverseMap();
        }
    }
}
