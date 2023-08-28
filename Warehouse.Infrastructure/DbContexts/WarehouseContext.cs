using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Entities;
using static Warehouse.Domain.Entities.Package;

namespace Warehouse.Infrastructure.DbContexts
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Container> Containers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
 
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {

        }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierContainer>()
             .HasKey(s => new { s.ContainerId, s.SupplierId });
            modelBuilder.Entity<Package>()
    .Property(p=> p.SpecialInstructions)
    .HasConversion<string>();
            modelBuilder.Entity<Customer>()
               .HasData(
              new Customer()
              {
                  Id = 1,
                  Name = "khadija"
              },
               new Customer()
               {
                   Id = 2,
                   Name = "sara"
               },
              new Customer()
              {
                  Id = 3,
                  Name = "laith"
              });
            modelBuilder.Entity<Supplier>()
               .HasData(
              new Supplier()
              {
                  Id = 4,
                  Name = "Yousif Supplier"
              },
               new Supplier()
               {
                   Id = 5,
                   Name = "Amro Supplier"
               },
              new Supplier()
              {
                  Id = 6,
                  Name = "Ahmad Supplier"
              });
            modelBuilder.Entity<Container>()
             .HasData(
               new Container()
               {
                   Id = 1,
                   
                   Type = "40 ft HC",

               },
               new Container()
               {
                   Id = 2,
                   Type = "20 ft FR",
               },
                new Container()
                {
                    Id = 3,
                    Type = "40 ft HC",

                });
            modelBuilder.Entity<SupplierContainer>()
             .HasData(
               new SupplierContainer()
               {
                   SupplierId = 4,

                   ContainerId = 1,

               },
               new SupplierContainer()
               {
                   SupplierId = 4,

                   ContainerId = 2,

               },
                new SupplierContainer()
                {
                    SupplierId = 5,

                    ContainerId = 1,

                }, new SupplierContainer()
                {
                    SupplierId = 5,

                    ContainerId = 3,

                }, new SupplierContainer()
                {
                    SupplierId = 6,

                    ContainerId = 2,

                });

            modelBuilder.Entity<Package>()
             .HasData(
               new Package()
               {
                   Id = 1,
                   Type= "box",
                   Dimensions=1,
                   SpecialInstructions= Instructions.dangerous,
                   CustomerId = 1,
                   ContainerId= 1,
               },
               new Package()
               {
                   Id = 2,
                   Type = "box",
                   Dimensions = 2,
                   SpecialInstructions = Instructions.perishable,
                   CustomerId = 1,
                   ContainerId = 2,
               },
                new Package()
                {
                    Id = 3,
                    Type = "cylinder",
                    Dimensions = 3,
                    SpecialInstructions = Instructions.dangerous,
                    CustomerId = 1,
                    ContainerId = 1,
                },
               new Package()
               {
                   Id = 4,
                   Type = "cylinder",
                   Dimensions = 4,
                   SpecialInstructions = Instructions.perishable,
                   CustomerId = 2,
                   ContainerId = 1,
               },
               new Package()
               {
                   Id = 5,
                   Type = "cylinder",
                   Dimensions = 1,
                   SpecialInstructions = Instructions.dangerous,
                   CustomerId = 2,
                   ContainerId = 2,
               },
               new Package()
               {
                   Id = 6,
                   Type = "box",
                   Dimensions = 5,
                   SpecialInstructions = Instructions.perishable,
                   CustomerId = 2,
                   ContainerId = 3,
               },
                new Package()
                {
                    Id = 7,
                    Type = "box",
                    Dimensions = 5,
                    SpecialInstructions = Instructions.dangerous,
                    CustomerId = 3,
                    ContainerId = 3,
                }

               );
            modelBuilder.Entity<Location>()
               .HasData(
              new Location()
              {
                  Id = 1,

                  Dimensions = 1,

              },
                new Location()
                {
                    Id = 2,

                    Dimensions = 2,

                },
               new Location()
               {
                   Id = 3,

                   Dimensions = 3,

               },
                new Location()
                {
                    Id = 4,

                    Dimensions = 4,

                },
                 new Location()
                 {
                     Id = 5,

                     Dimensions = 5,

                 }
                );
            modelBuilder.Entity<SchedulingProcess>()
             .HasData(
               new SchedulingProcess()
               {
                   Id = 1,
                   PackageId = 1,

                   LocationId = 1,
                   ExpectedInDate = DateTime.Now,
                   ExpectedOutDate = (DateTime.Now).AddDays(3),
                   ActualInDate= DateTime.Now,
                   ActualOutDate= null,

               },
                new SchedulingProcess()
                {
                    Id = 2,
                    PackageId = 4,

                    LocationId = 4,
                    ExpectedInDate = (DateTime.Now).AddDays(3),
                    ExpectedOutDate = (DateTime.Now).AddDays(5),
                    ActualInDate= null,
                    ActualOutDate = null,

                },
                new SchedulingProcess()
                {
                    Id = 3,
                    PackageId = 2,

                    LocationId = 2,
                    ExpectedInDate = (DateTime.Now).AddDays(-3),
                    ExpectedOutDate = (DateTime.Now).AddDays(2),
                    ActualInDate = (DateTime.Now).AddDays(-2),// late one day
                    ActualOutDate = null,

                }, 
                new SchedulingProcess()
                {
                    Id = 4,
                    PackageId = 3,

                    LocationId = 3,
                    ExpectedInDate = (DateTime.Now).AddDays(-6),
                    ExpectedOutDate = (DateTime.Now).AddDays(-1),
                    ActualInDate = null,//late 4 days , will be deleted
                    ActualOutDate = null,

                },
                new SchedulingProcess()
                {
                    Id = 5,
                    PackageId = 5,

                    LocationId = 1,
                    ExpectedInDate = (DateTime.Now).AddDays(-4),
                    ExpectedOutDate = (DateTime.Now).AddDays(-1),
                    ActualInDate = (DateTime.Now).AddDays(-4),
                    ActualOutDate = (DateTime.Now).AddDays(-1),

                },
                 new SchedulingProcess()
                 {
                     Id = 6,
                     PackageId = 6,

                     LocationId = 5,
                     ExpectedInDate = (DateTime.Now).AddDays(-6),
                     ExpectedOutDate = (DateTime.Now).AddDays(-3),
                     ActualInDate = (DateTime.Now).AddDays(-5),
                     ActualOutDate = (DateTime.Now).AddDays(-3),

                 }, new SchedulingProcess()
                 {
                     Id = 7,
                     PackageId = 7,

                     LocationId = 5,
                     ExpectedInDate = (DateTime.Now).AddDays(-3),
                     ExpectedOutDate = (DateTime.Now).AddDays(-1),
                     ActualInDate = (DateTime.Now).AddDays(-2),// late one day 
                     ActualOutDate = (DateTime.Now).AddDays(-1),

                 }); ;
            base.OnModelCreating(modelBuilder);
        }
    }
}
