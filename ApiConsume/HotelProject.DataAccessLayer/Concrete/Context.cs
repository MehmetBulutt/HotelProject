using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        override
            protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Mehmet-Bulut\\SQLEXPRESS; initial catalog=ApiDb;integrated security=true");
        }
        public DbSet<Room> Rooms { get; set; }
    }
}
