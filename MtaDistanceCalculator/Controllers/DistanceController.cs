using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MtaDistanceCalculator.Models;
using MtaDistanceCalculator.Statics;

namespace MtaDistanceCalculator.Controllers
{
    public class DistanceController : ApiController
    {
	    private readonly MtaDistanceCalculatorContext _db = new MtaDistanceCalculatorContext();

		// GET: api/Stations/5/Distance/6
	    [Route("api/stations/{id1:int}/distance/{id2:int}")]
		[ResponseType(typeof(DistanceDto))]
	    public async Task<IHttpActionResult> GetDistance(int id1, int id2)
	    {
		    var station1 = await _db.Stations.FindAsync(id1);
		    if (station1 == null)
		    {
			    return NotFound();
		    }

			var station2 = await _db.Stations.FindAsync(id2);
		    if (station2 == null)
		    {
			    return NotFound();
		    }

			var distanceDto = new DistanceDto
			                  {
				                  Distance = DistanceAlgorithm.DistanceBetweenPlaces(station1.StopLongitude, station1.StopLatitude, station2.StopLongitude, station2.StopLatitude)
			                  };

			return Ok(distanceDto);
	    }

	}
}
