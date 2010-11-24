using System;
using SpeakerNet.Infrastructure.Bootstrap;
using SpeakerNet.Models;
using StructureMap;

namespace SpeakerNet.Data
{
    public class DatabaseConfiguration : IBootstrapItem
    {
        private readonly IContainer container;

        public DatabaseConfiguration(IContainer container)
        {
            this.container = container;
        }

        public void Execute()
        {
        }
    }
}