using RaceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceApp.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            List<Inspection> carInspection = new List<Inspection> { 
                new Inspection { Id = Guid.NewGuid(), InspectionType = InspectionTypeEnum.TOW_STRAP, Passed = true },
                new Inspection { Id = Guid.NewGuid(), InspectionType = InspectionTypeEnum.LESS_THAN_85_TIRE_WEAR, Passed = true }
            };

            List<Inspection> truckInspection = new List<Inspection> {
                new Inspection { Id = Guid.NewGuid(), InspectionType = InspectionTypeEnum.TOW_STRAP, Passed = true },
                new Inspection { Id = Guid.NewGuid(), InspectionType = InspectionTypeEnum.NOT_LIFTED_MORE_THAN_5_INCHES, Passed = true }
            };
            Vehicle vehicle1 = new Vehicle { Id = Guid.NewGuid(), Model = "Ford F150", TopSpeed = 265, Type = VehicleTypeEnum.Truck, InspectionTypes = truckInspection };
            Vehicle vehicle2 = new Vehicle { Id = Guid.NewGuid(), Model = "Nissan GTR", TopSpeed = 315, Type = VehicleTypeEnum.Car, InspectionTypes = carInspection };

            Track track1 = new Track { Id = Guid.NewGuid(), Length = 20, Location = "Calgary", Vehicles = new List<Vehicle> { vehicle1, vehicle2 } };


            if (!context.Tracks.Any())
            {
                context.Tracks.Add(track1);
                context.SaveChanges();
            }
        }
    }
}
