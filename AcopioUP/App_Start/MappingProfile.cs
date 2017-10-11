using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcopioUP.Dtos;
using AcopioUP.Models;
using AutoMapper;
using AutoMapper.Configuration;

namespace AcopioUP.App_Start
{
    public class MappingProfile : Profile
    {

        private static MapperConfigurationExpression _configuration;

        private static void Initialize()
        {
            _configuration = new MapperConfigurationExpression();
            _configuration.CreateMap<Victim, VictimDto>();
            _configuration.CreateMap<VictimDto, Victim>();
        }

        public static MapperConfigurationExpression ConfigurationProfile()
        {
            if (_configuration == null)
                Initialize();
            return _configuration;
        }
    }
}