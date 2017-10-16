namespace MtaDistanceCalculator.Models
{
	public class StationDto
	{
		public int Id { get; set; }
		public string MtaId { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}