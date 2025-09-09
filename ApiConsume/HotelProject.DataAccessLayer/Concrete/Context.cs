using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=DESKTOP-BPMLTJH\\SQLEXPRESS;initial catalog=ApiDb;integrated security=true;Trust Server Certificate=True; ");
            optionsBuilder.UseSqlServer(@"server=DESKTOP-NDIDOSR\SQLEXPRESS;initial catalog=ApiDb;integrated security=true;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        { 
            base.OnModelCreating(builder);
            
            builder.Entity<Guest>(entry => 
            { 
                entry.ToTable("Guests", tb => tb.HasTrigger("Guestincrase"));
            });

            builder.Entity<Room>(entry =>
            {
                entry.ToTable("Rooms", tb => tb.HasTrigger("Roomincrase"));
            });

            builder.Entity<Staff>(entry =>
            {
                entry.ToTable("Staffs", tb => tb.HasTrigger("Staffincrase"));
            });

        }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Staff>? Staffs { get; set; }
        public DbSet<Subscribe>? Subscribes { get; set; }
        public DbSet<Testimonial>? Testimonials { get; set; }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Guest>? Guests { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<SendMessage>? SendMessages { get; set; }
        public DbSet<MessageCategory>? MessageCategories { get; set; }
        public DbSet<WorkLocation>? WorkLocations { get; set; }

    }
}
