using NUnit.Framework;

using System.Linq;

using WP.WebAPI.Controllers;
using WP.WebAPI.Models;
using WP.WebAPI.Services;

namespace WP.WebAPI.Tests
{
    public class PlantsServiceTests
    {
        IPlantsService _service;

        [SetUp]
        public void Setup()
        {
            // Issue #10, Replace this with a service instead of a direct DB Context
            // var dbOptions = new Microsoft.EntityFrameworkCore.DbContextOptions<WPContext>();
            // WPContext context = new WPContext(dbOptions);
            // _controller = new PlantModelsController(context);
            _service = new MockedPlantsService();
        }

        [Test]
        [TestCase(12)]
        [TestCase(69)]
        public void StubbedDataExists(long id)
        {
            Assert.IsTrue(_service.GetPlant(id) != null);
        }

        [Test]
        [TestCase(10, "NewPlant", "NewPlantOnTheBlockus")]
        public void AddPlant(long id, string friendlyName, string sciName) {
            _service.AddPlant(new PlantModel() {
                Id = id, 
                FriendlyName = friendlyName, 
                ScientificName = sciName
            });
            Assert.IsTrue(_service.GetPlant(id) != null);
        }
    }
}