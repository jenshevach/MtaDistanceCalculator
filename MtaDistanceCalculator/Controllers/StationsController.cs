using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MtaDistanceCalculator.Models;

namespace MtaDistanceCalculator.Controllers
{
	public class StationsController : ApiController
	{
		private readonly MtaDistanceCalculatorContext _db = new MtaDistanceCalculatorContext();

		// GET: api/Stations
		public IQueryable<StationDto> GetStations()
		{
			var stations = _db.Stations.Select(
				s => new StationDto
				     {
					     Id = s.Id,
						 MtaId = s.StopId,
					     Name = s.StopName,
					     Latitude = s.StopLatitude,
					     Longitude = s.StopLongitude
				     });
			return stations;
		}

		// GET: api/Stations/5
		[ResponseType(typeof(StationDto))]
		public async Task<IHttpActionResult> GetStation(int id)
		{
			Station station = await _db.Stations.FindAsync(id);
			if (station == null)
			{
				return NotFound();
			}

			return Ok(ConvertStationToDto(station));
		}

		// PUT: api/Stations/5
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutStation(int id, Station station)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != station.Id)
			{
				return BadRequest();
			}

			_db.Entry(station).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StationExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/Stations
		[ResponseType(typeof(StationDto))]
		public async Task<IHttpActionResult> PostStation(Station station)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_db.Stations.Add(station);
			await _db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = station.Id }, ConvertStationToDto(station));
		}

		// DELETE: api/Stations/5
		[ResponseType(typeof(StationDto))]
		public async Task<IHttpActionResult> DeleteStation(int id)
		{
			Station station = await _db.Stations.FindAsync(id);
			if (station == null)
			{
				return NotFound();
			}

			_db.Stations.Remove(station);
			await _db.SaveChangesAsync();

			return Ok(ConvertStationToDto(station));
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool StationExists(int id)
		{
			return _db.Stations.Count(e => e.Id == id) > 0;
		}

		private StationDto ConvertStationToDto(Station s)
		{
			return new StationDto
			       {
				       Id = s.Id,
					   MtaId = s.StopId,
				       Name = s.StopName,
				       Latitude = s.StopLatitude,
				       Longitude = s.StopLongitude
			       };
		}
	}
}