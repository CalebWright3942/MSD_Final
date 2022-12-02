using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InventoryApp.Data;
using System;
using System.Linq;

namespace InventoryApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InventoryAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<InventoryAppContext>>()))
            {
                // Look for any movies.
                if (context.Inventory.Any())
                {
                    return;   // DB has been seeded
                }

                context.Inventory.AddRange(
                    new Inventory
                    {
                        //Id = 1,
                        ManufacturerSerialNumber = 1000,
                        OfficeRoomNumber = "100",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "12GB RAM, Intel Core i5, 240 GB SSD",
                        OperatingSystem =  "Windows",
                        OwnerName = "George Jones",
                        InstallationDate = DateTime.Now,
                        Price = 598.00M
                    },
                    new Inventory
                    {
                        //Id = 2,
                        ManufacturerSerialNumber = 1001,
                        OfficeRoomNumber = "215",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "12GB RAM, Intel Core i5, 512 GB SSD",
                        OperatingSystem = "Windows",
                        OwnerName = "Jessica Reynolds",
                        InstallationDate = DateTime.Now,
                        Price = 629.99M
                    },
                    new Inventory
                    {
                        //Id = 3,
                        ManufacturerSerialNumber = 1002,
                        OfficeRoomNumber = "209",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "16GB RAM, Intel Core i7, 512 GB SSD",
                        OperatingSystem = "macOS",
                        OwnerName = "Dillon Lin",
                        InstallationDate = DateTime.Now,
                        Price = 799.99M
                    },
                    new Inventory
                    {
                        //Id = 4,
                        ManufacturerSerialNumber = 1003,
                        OfficeRoomNumber = "111",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "12GB RAM, Intel Core i7, 1 TB SSD",
                        OperatingSystem = "macOS",
                        OwnerName = "Jaya Manning",
                        InstallationDate = DateTime.Now,
                        Price = 750.00M
                    },
                    new Inventory
                    {
                        //Id = 5,
                        ManufacturerSerialNumber = 1004,
                        OfficeRoomNumber = "359",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "16GB RAM, Intel Core i5, 512 GB SSD",
                        OperatingSystem = "Windows",
                        OwnerName = "Katherine Daugherty",
                        InstallationDate = DateTime.Now,
                        Price = 599.99M
                    },
                    new Inventory
                    {
                        //Id = 6,
                        ManufacturerSerialNumber = 1005,
                        OfficeRoomNumber = "118",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "12GB RAM, Intel Core i7, 250 GB SSD",
                        OperatingSystem = "macOS",
                        OwnerName = "Jasper Mathis",
                        InstallationDate = DateTime.Now,
                        Price = 449.99M
                    },
                    new Inventory
                    {
                        //Id = 7,
                        ManufacturerSerialNumber = 1006,
                        OfficeRoomNumber = "118",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "16GB RAM, Intel Core i7, 1 TB SSD",
                        OperatingSystem = "Windows",
                        OwnerName = "Marshall Winter",
                        InstallationDate = DateTime.Now,
                        Price = 849.99M
                    },
                    new Inventory
                    {
                        //Id = 8,
                        ManufacturerSerialNumber = 1007,
                        OfficeRoomNumber = "118",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "12GB RAM, Intel Core i5, 512 GB SSD",
                        OperatingSystem = "Windows",
                        OwnerName = "Ellena Vazquez",
                        InstallationDate = DateTime.Now,
                        Price = 615.00M
                    },
                    new Inventory
                    {
                        //Id = 9,
                        ManufacturerSerialNumber = 1008,
                        OfficeRoomNumber = "309",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "16GB RAM, Intel Core i5, 512 GB SSD",
                        OperatingSystem = "macOS",
                        OwnerName = "Ruth Gill",
                        InstallationDate = DateTime.Now,
                        Price = 750.00M
                    },
                    new Inventory
                    {
                        //Id = 10,
                        ManufacturerSerialNumber = 1009,
                        OfficeRoomNumber = "100",
                        OfficeLocation = "Science Building",
                        ComputerSpecification = "32GB RAM, Intel Core i7, 1 TB SSD",
                        OperatingSystem = "Windows",
                        OwnerName = "Nathaniel Ruiz",
                        InstallationDate = DateTime.Now,
                        Price = 1200.00M
                    }



                );
                context.SaveChanges();
            }
        }
    }
}
