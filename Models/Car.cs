using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarMaintenanceTracker.Api.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Make { get; set; } = null!;

        [Required, StringLength(100)]
        public string Model { get; set; } = null!;

        [Range(1886, 2100)]
        public int Year { get; set; }

        // VIN is 17 chars for modern vehicles
        [Required, StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; } = null!;

        // Navigation property
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
    }
}