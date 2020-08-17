using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaceApp.Models
{
    public class Vehicle
    {
		[Key]
		public Guid Id { get; set; }
		public string Model { get; set; }
		public decimal TopSpeed { get; set; }
        public VehicleTypeEnum Type { get; set; }
		public Guid TrackId { get; set; }
		public List<Inspection> InspectionTypes { get; set; }
		public bool Inspected { 
			get
			{
				if (InspectionTypes == null) return false;

				bool hasTowStrap = InspectionTypes.Select(t => t.InspectionType).Contains(InspectionTypeEnum.TOW_STRAP);
				bool notLifted = InspectionTypes.Select(t => t.InspectionType).Contains(InspectionTypeEnum.NOT_LIFTED_MORE_THAN_5_INCHES);
				bool tireWear = InspectionTypes.Select(t => t.InspectionType).Contains(InspectionTypeEnum.LESS_THAN_85_TIRE_WEAR);
				if (Type == VehicleTypeEnum.Car)
                {
					return InspectionTypes.Count == 2 
						&& hasTowStrap
						&& tireWear
						&& InspectionTypes.All(i => i.Passed);

				} else if (this.Type == VehicleTypeEnum.Truck)
				{
					return InspectionTypes.Count == 2 
						&& hasTowStrap
						&& notLifted
						&& InspectionTypes.All(i => i.Passed); ;

				}
				throw new Exception("Invalid vehicle type");
			}

		}

		public bool IsValid
        {
			get
            {
				string model = Model ?? "";
				return TopSpeed > 0 && !String.IsNullOrEmpty(model.Trim()) && Enum.IsDefined(typeof(VehicleTypeEnum), Type);
            }
        }
	}

	public class PostVehicle
	{
		public string Model { get; set; }
		public decimal TopSpeed { get; set; }
		public VehicleTypeEnum Type { get; set; }
		public List<PostInspection> InspectionTypes { get; set; }
		public string TrackId { get; set; } 
	}
}
