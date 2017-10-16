using System.IO;
using MtaDistanceCalculator.Models;

namespace MtaDistanceCalculator.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MtaDistanceCalculatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MtaDistanceCalculatorContext context)
        {
	        var stations = File.ReadAllLines("D:\\home\\site\\wwwroot\\Migrations\\stops.csv")
	                                     .Select(Station.FromCsv)
	                                     .ToList();

			context.Stations.AddOrUpdate(
				s => s.StopId,
				stations.ToArray());
        }
    }
}
