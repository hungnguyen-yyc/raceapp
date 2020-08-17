using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceApp.DAL;
using RaceApp.Models;

namespace RaceApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return await _context.Vehicles.Include(nameof(Vehicle.InspectionTypes)).ToListAsync();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(PostVehicle vehicle)
        {
            List<Inspection> inspections = vehicle.InspectionTypes.Select(i => new Inspection { Id = Guid.NewGuid(), InspectionType = i.InspectionType, Passed = i.Passed }).ToList();
            Vehicle newVehicle = new Vehicle { Id = Guid.NewGuid(), InspectionTypes = inspections, Model = vehicle.Model, TopSpeed = vehicle.TopSpeed, Type = vehicle.Type, TrackId = Guid.Parse(vehicle.TrackId) };

            if (!newVehicle.IsValid) {
                return BadRequest("Invalid new vehicle's info");
            }

            if (newVehicle.Inspected)
            {
                _context.Vehicles.Add(newVehicle);

                var track = _context.Tracks.Include(nameof(Track.Vehicles)).FirstOrDefault(v => v.Id == newVehicle.TrackId);
                if (track == null)
                {
                    return BadRequest("Track is not available.");
                }

                bool isValidTrack = track.IsValidTrack;
                if (!track.IsValidTrack)
                {
                    return BadRequest("Track is full.");
                }

                await _context.SaveChangesAsync();
                return CreatedAtAction("GetVehicle", new { id = newVehicle.Id }, newVehicle);
            } else
            {
                return BadRequest("Vehicle not passed the inspection");
            }
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(Guid id)
        {
            var vehicle = _context.Vehicles.Include(nameof(Vehicle.InspectionTypes)).FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            foreach (var inspection in vehicle.InspectionTypes)
            {
                _context.Inspections.Remove(inspection);
            }
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }
    }
}
