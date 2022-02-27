using Microsoft.EntityFrameworkCore;
using WebAppMVC.ViewModels;

namespace WebAppMVC.Models
{
    public class DatabaseContext : DbContext
    {
       
        public virtual DbSet<Consumer> Consumers => Set<Consumer>();
        public virtual DbSet<Consumption> Consumptions => Set<Consumption>();
        public virtual DbSet<Price> Prices => Set<Price>();
        public virtual DbSet<Weather> Weathers => Set<Weather>();
     

        public DatabaseContext()
        {
            //Database.EnsureDeleted();//раскомментировать при необходимости удалить данные из базы и саму базу
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = TPlusBricks.db");
        }

        //public DbSet<WebAppMVC.ViewModels.ConsumerViewModel> ConsumerViewModel { get; set; }


    }
}
