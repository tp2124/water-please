using NUnit.Framework;

using System.Linq;

using WP.WebAPI.Controllers;
using WP.WebAPI.Models;
using WP.WebAPI.Services;

namespace WP.WebAPI.Tests
{
    public class PlantModelControllerTests
    {
        // PlantModelsController _controller;

        [SetUp]
        public void Setup()
        {
            // Issue #10, Replace this with a service instead of a direct DB Context
            // var dbOptions = new Microsoft.EntityFrameworkCore.DbContextOptions<WPContext>();
            // WPContext context = new WPContext(dbOptions);
            // _controller = new PlantModelsController(context, new MockedPlantService());
        }
    }
}