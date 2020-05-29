using System;
using Airline.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Airline.DAL.DBContext
{
    public partial class AirlineContext : IdentityDbContext<User>
    {
        public AirlineContext()
        {
        }

        public AirlineContext(DbContextOptions<AirlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FlightSchedule> FlightSchedule { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP\\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

                                            
         modelBuilder.Entity<FlightSchedule>(entity =>
            {
                

                entity.ToTable("Flight_schedule");

                entity.Property(e => e.DepartureDate)
                    .IsRequired()
                    .HasColumnName("Departure_date")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureTime)
                    .IsRequired()
                    .HasColumnName("Departure_time")
                    .HasMaxLength(30)
                    .IsUnicode(false);
               
            });

           modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.Airlines)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Froms)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Wheres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                modelBuilder.Entity<Flight>()
                .HasOne<Passenger>()
                .WithMany()
                .HasForeignKey(p => p.PassengerId);

                modelBuilder.Entity<Flight>()
               .HasOne<FlightSchedule>()
               .WithMany()
               .HasForeignKey(p => p.FlightSheduleId);

            });

            modelBuilder.Entity<Passenger>().HasData(
                  new Passenger[] {
                    new Passenger { Id = 1, Name = "Michael", LastName = "Tsyntar" }

                  });
           
            modelBuilder.Entity<FlightSchedule>().HasData(
                 new FlightSchedule[] {
                    new FlightSchedule { Id = 1, DepartureDate = "16.06.2020", DepartureTime = "04:40:00"}

                 });

            modelBuilder.Entity<Flight>().HasData(
                 new Flight[] {
                    new Flight { Id = 1,PassengerId =1, FlightSheduleId = 1,Froms = "Madrid", Wheres = "Kiev",Airlines = "Wizzair" }

                 });
            modelBuilder.Entity<User>().HasData(
               new User[] {
                    new User { UserName = "Misa", FirstName = "Michael", LastName = "TSyntar", Email = "misa@gmail.com"}
               });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
 
