using Microsoft.AspNetCore.Mvc;
using CarMaintenanceTracker.Api.Models;
using CarMaintenanceTracker.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace CarMaintenanceTracker.Api.Controllers
{
    [ApiController]
    [Route("cars")]
    [Authorize]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMaintenanceService _maintenanceService;

        public CarsController(ICarService carService, IMaintenanceService maintenanceService)
        {
            _carService = carService;
            _maintenanceService = maintenanceService;
        }

        // GET /cars
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        // GET /cars/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        // POST /cars
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            var createdCar = await _carService.AddCarAsync(car);
            return CreatedAtAction(nameof(GetCar), new { id = createdCar.Id }, createdCar);
        }

        // PUT /cars/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            var updated = await _carService.UpdateCarAsync(id, car);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE /cars/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleted = await _carService.DeleteCarAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // GET /cars/{carId}/maintenance
        [HttpGet("{carId}/maintenance")]
        public async Task<IActionResult> GetMaintenanceRecords(int carId)
        {
            var records = await _maintenanceService.GetMaintenanceRecordsAsync(carId);
            return Ok(records);
        }

        // POST /cars/{carId}/maintenance
        [HttpPost("{carId}/maintenance")]
        public async Task<IActionResult> AddMaintenanceRecord(int carId, [FromBody] MaintenanceRecord record)
        {
            var createdRecord = await _maintenanceService.AddMaintenanceRecordAsync(carId, record);
            return CreatedAtAction(nameof(GetMaintenanceRecords), new { carId = carId }, createdRecord);
        }
    }
}
