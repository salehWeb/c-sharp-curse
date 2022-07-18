using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/superhero")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IHeroService heroService;

        public SuperHeroController(IHeroService heroService)
        {
            this.heroService = heroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Hero>>> Get()
        {
            return heroService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Hero> Get(string id)
        {
            Hero hero = heroService.Get(id);

            if (hero == null)
            {
                return NotFound($"her with this id {id} not found");
            }

            return hero;
        }

        [HttpPost]
        public ActionResult<Hero> Post([FromBody] Hero vaule)
        {
            heroService.Create(vaule);
            return CreatedAtAction(nameof(Get), new { id = vaule.Id }, vaule);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Hero vaule)
        {
            var isExistingHero = heroService.Get(id);

            if (isExistingHero == null)
            {
                return NotFound("Hero dose not Exist");
            }

            heroService.Update(id, vaule);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var isExistingHero = heroService.Get(id);

            if (isExistingHero == null)
            {
                return NotFound("Hero dose not Exist");
            }

            heroService.Remove(id);

            return Ok("Hero Deleted");
        }
    }
}