using System;
using System.Data.Entity;
using System.Web;
using SpeakerNet.Models;

namespace SpeakerNet.Data
{
    public class SpeakerNetDbContext : DbContext
    {
        public SpeakerNetDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Address>();
            modelBuilder.ComplexType<Contact>();
            modelBuilder.Entity<Session>().HasRequired(e => e.Speaker).WithMany().Map(e => e.MapKey("SpeakerId"));
            modelBuilder.Entity<Session>().HasRequired(e => e.Event).WithMany().Map(e => e.MapKey("EventId"));
            modelBuilder.Entity<SpeakerPicture>().HasRequired(e => e.Speaker).WithMany().Map(e => e.MapKey("SpeakerId"));


            modelBuilder.Entity<Speaker>().Property(e => e.Address.Street).HasColumnName("Street");
            modelBuilder.Entity<Speaker>().Property(e => e.Address.ZipCode).HasColumnName("ZipCode");
            modelBuilder.Entity<Speaker>().Property(e => e.Address.City).HasColumnName("City");
            modelBuilder.Entity<Speaker>().Property(e => e.Address.Country).HasColumnName("Country");

            modelBuilder.Entity<Speaker>().Property(e => e.Contact.EMail).HasColumnName("EMail");
            modelBuilder.Entity<Speaker>().Property(e => e.Contact.Fax).HasColumnName("Fax");
            modelBuilder.Entity<Speaker>().Property(e => e.Contact.Phone).HasColumnName("Phone");
            modelBuilder.Entity<Speaker>().Property(e => e.Contact.Homepage).HasColumnName("Homepage");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SpeakerPicture> SpeakerPictures { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}