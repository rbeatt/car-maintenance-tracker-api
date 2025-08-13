using System;
using System.ComponentModel.DataAnnotations;

namespace CarMaintenanceTracker.Api.Models
{
    public class MaintenanceRecord
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        [Required, StringLength(100)]
        public string ServiceType { get; set; } = null!;

        [Required]
        public DateTime ServiceDate { get; set; }

        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        public Car Car { get; set; } = null!;
    }
}
