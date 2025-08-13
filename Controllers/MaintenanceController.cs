using Microsoft.AspNetCore.Mvc;
using CarMaintenanceTracker.Api.Models;
using CarMaintenanceTracker.Api.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CarMaintenanceTracker.Api.Controllers
{
    [ApiController]
    [Route("maintenance")]
    [Authorize]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        // PUT /maintenance/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceRecord(int id, [FromBody] MaintenanceRecord record)
        {
            var updated = await _maintenanceService.UpdateMaintenanceRecordAsync(id, record);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE /maintenance/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceRecord(int id)
        {
            var deleted = await _maintenanceService.DeleteMaintenanceRecordAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
