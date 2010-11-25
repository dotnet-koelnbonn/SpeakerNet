using System;
using System.Data.Entity;
using System.Web;
using SpeakerNet.Models;

namespace SpeakerNet.Data
{
    public class SpeakerNetContext : DbContext
    {
        public SpeakerNetContext() : base(CreateConnectionString()) {}

        private static string CreateConnectionString()
        {
            var filename = HttpContext.Current.Server.MapPath("~/App_Data/SpeakerNet.sdf");
            return string.Format("Data Source={0}", filename);
        }

        protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Address>();
            modelBuilder.ComplexType<Contact>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Speaker> Speakers { get; set; }
    }
}