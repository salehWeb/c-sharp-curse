using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/superhero")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHero() {

            return new List<SuperHero>{ new SuperHero {
                Name = "Super Hero",
                FirstName = "hello",
                LastName = "SuperHero",
                Place = "Super"
            } }; 
        }
    }
}