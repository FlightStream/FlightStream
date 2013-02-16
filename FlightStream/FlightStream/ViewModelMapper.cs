using AutoMapper;
using FlightStream.Models;
using FlightStream.ViewModels;

namespace FlightStream
{
    public class ViewModelMapper
    {
        public static void Map()
        {
            Mapper.CreateMap<Aircraft, AircraftViewModel>();
            Mapper.CreateMap<AircraftTemplate, AircraftTemplateViewModel>();
            Mapper.CreateMap<Client, ClientViewModel>();
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.CreateMap<Settings, SettingsViewModel>();

        }
    }
}