using System;

namespace MtaDistanceCalculator.Statics
{
	internal static class DistanceAlgorithm
	{
		private const double PIx = 3.141592653589793;
		private const double Radius = 6378.16;

		/// <summary>
		/// Convert degrees to Radians
		/// </summary>
		/// <param name="x">Degrees</param>
		/// <returns>The equivalent in radians</returns>
		public static double Radians(double x)
		{
			return x * PIx / 180;
		}

		/// <summary>
		/// Calculate the distance between two places.
		/// </summary>
		/// <param name="lon1">Longitude of 1st place</param>
		/// <param name="lat1">Latiitude of 1st place</param>
		/// <param name="lon2">Longitude of 2nd place</param>
		/// <param name="lat2">Latiitude of 2nd place</param>
		/// <returns>double</returns>
		public static double DistanceBetweenPlaces(
			double lon1,
			double lat1,
			double lon2,
			double lat2)
		{
			var dlon = Radians(lon2 - lon1);
			var dlat = Radians(lat2 - lat1);

			var a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
			var angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
			return angle * Radius;
		}
	}
}