using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RaceApp.DAL;
using RaceApp.Models;

namespace RaceApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TracksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return await _context.Tracks.Include(t => t.Vehicles).ThenInclude(v => v.InspectionTypes).ToListAsync();
        }
    }
}
