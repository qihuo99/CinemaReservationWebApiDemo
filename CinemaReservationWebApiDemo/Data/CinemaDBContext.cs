using CinemaReservationWebApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationWebApiDemo.Data
{
    public class CinemaDBContext : DbContext
    {
        public CinemaDBContext(DbContextOptions<CinemaDBContext> options) : base(options)
        {

        }

        //public DbSet<MovieTest1> Movies { get; set; }

        public DbSet<Movie> Movies { get; set; }

    }
}
