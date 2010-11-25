using System;
using AutoMapper;
using SpeakerNet.Infrastructure.Bootstrap;
using SpeakerNet.Models;

namespace SpeakerNet.Initialize
{
    public class MapperInitialize : IBootstrapItem
    {
        public void Execute()
        {
            Mapper.CreateMap<Speaker, Speaker>();
        }
    }
}