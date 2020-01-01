using NUnit.Framework;

using System.Linq;
using System.Threading.Tasks;

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
            _service.AddPlantAsync(new PlantModel() {
                Id = id, 
                FriendlyName = friendlyName, 
                ScientificName = sciName
            });
            Assert.IsTrue(_service.GetPlant(id) != null);
        }
    }
}