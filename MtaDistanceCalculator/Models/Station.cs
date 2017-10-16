using System;
using System.ComponentModel.DataAnnotations;

namespace MtaDistanceCalculator.Models
{
	public class Station
	{
		public int Id { get; set; }
		[Required]
		public string StopId { get; set; }
		[Required]
		public string StopName { get; set; }
		[Required]
		public double StopLatitude { get; set; }
		[Required]
		public double StopLongitude { get; set; }

		public static Station FromCsv(string row)
		{
			// Format of row: stop_id,stop_name,stop_lat,stop_lon
			var values = row.Split(',');
			var station = new Station
			              {
				              StopId = values[0],
				              StopName = values[1],
				              StopLatitude = Convert.ToDouble(values[2]),
				              StopLongitude = Convert.ToDouble(values[3])
			              };
			return station;
		}
	}
}