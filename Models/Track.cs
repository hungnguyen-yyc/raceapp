using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaceApp.Models
{
    public class Track
    {
        [Key]
        public Guid Id { get; set; }
        public string Location { get; set; }
        public decimal Length { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public bool IsValidTrack { 
            get
            {
                string location = Location ?? "";
                return Length > 0 
                    && !string.IsNullOrEmpty(location.Trim()) 
                    && Vehicles.Count > 0 
                    && Vehicles.Count < 6;
            } 
        }
    }
}
