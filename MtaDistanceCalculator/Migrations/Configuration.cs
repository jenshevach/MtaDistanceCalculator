using System;
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
	        var defaultSeedPath = "C://code//other//MtaDistanceCalculator//MtaDistanceCalculator//Migrations//stops.csv";
	        var envSeedPath = Environment.GetEnvironmentVariable("SEED_DATA_PATH");
	        var stations = File.ReadAllLines(envSeedPath ?? defaultSeedPath)
	                                     .Select(Station.FromCsv)
	                                     .ToList();

			context.Stations.AddOrUpdate(
				s => s.StopId,
				stations.ToArray());
        }
    }
}
