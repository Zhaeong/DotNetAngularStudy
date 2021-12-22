using System;
using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Models{
    public partial class myDBContext: DbContext
    {
        public myDBContext(DbContextOptions<myDBContext> options): base(options){


        }
        public DbSet<heroes> heroes {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<heroes>().ToTable("heroes");
        }
    }
}
