using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class RegionsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington",
                    Code = "WLG",
                    Area = 2224324,
                    Lat = -1.232,
                    Long = 299.32,
                    Population = 53453342,
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "AuckLand",
                    Code = "AUCK",
                    Area = 8653744,
                    Lat = 53.346,
                    Long = 343.33,
                    Population = 954843237
                }
            };

            return Ok(regions);
        }
    }
}
