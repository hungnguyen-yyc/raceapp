using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaceApp.Models
{
    public class Inspection
    {
        [Key]
        public Guid Id { get; set; }
        public InspectionTypeEnum InspectionType { get; set; }
        public bool Passed { get; set; }
    }

    public class PostInspection
    {
        public InspectionTypeEnum InspectionType { get; set; }
        public bool Passed { get; set; }
    }
}
