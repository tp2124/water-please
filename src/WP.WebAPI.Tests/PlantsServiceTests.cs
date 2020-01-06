using NUnit.Framework;

using System;
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
            Assert.IsTrue(_service.PlantExists(id));
        }

        [Test]
        [TestCase(12)]
        public void DeletePlant(long id) {
            _service.DeletePlantAsync(id);
            Assert.IsNull(_service.GetPlant(id));
            Assert.IsFalse(_service.PlantExists(id));
        }

        [Test]
        [TestCase(12, "ReWrotePlant", "ReWroteBigPlantuscus")]
        public void EditPlant(long existingId, string newFriendlyName, string newSciName) {
            bool result = _service.EditPlantAsync(new PlantModel() {
                                        Id = existingId,
                                        FriendlyName = newFriendlyName,
                                        ScientificName = newSciName
            }).Result;
            Assert.IsTrue(result);

            PlantModel editedPlant = _service.GetPlant(existingId);
            Console.WriteLine($"editedPlant: {editedPlant.Id}, {editedPlant.FriendlyName}, {editedPlant.ScientificName} ");
            Assert.IsTrue(editedPlant.Id == existingId);
            Assert.IsTrue(editedPlant.FriendlyName.Equals(newFriendlyName));
            Assert.IsTrue(editedPlant.ScientificName.Equals(newSciName));
        }
    }
}