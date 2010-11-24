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

        public DbSet<Speaker> Speakers { get; set; }
    }
}