using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IHeroService
    {
        List<Hero> Get();
        Hero Get(string id);
        Hero Create(Hero hero);
        void Update(string id, Hero hero);
        void Remove(string id);
    }
}
