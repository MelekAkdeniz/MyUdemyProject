﻿using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
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
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-BPMLTJH\\SQLEXPRESS;initial catalog=ApiDb;integrated security=true;Trust Server Certificate=True; ");
        }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Staff>? Staffs { get; set; }
        public DbSet<Subscribe>? Subscribes { get; set; }
        public DbSet<Testimonial>? Testimonials { get; set; }
        
    }
}
//Data Source = DESKTOP - BPMLTJH\SQLEXPRESS; Initial Catalog = ; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate=True; Application Intent = ReadWrite; Multi Subnet Failover=False