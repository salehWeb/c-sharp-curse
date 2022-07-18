using WebApplication1.Models;
using MongoDB.Driver;

namespace WebApplication1.Services
{
    public class HeroService : IHeroService
    {
        private readonly IMongoCollection<Hero> _hero;

        public HeroService(ISuperHeroDatabaseSettings settings, IMongoClient mongoClient)
        {
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _hero = dataBase.GetCollection<Hero>(settings.HerosCollectionName);
        }

        public Hero Create(Hero hero)
        {
            _hero.InsertOne(hero);
            return hero;
        }

        public List<Hero> Get()
        {
            return _hero.Find(hero => true).ToList();
        }

        public Hero Get(string id)
        {
            return _hero.Find(hero => hero.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _hero.DeleteOne(hero => hero.Id == id);
        }

        public void Update(string id, Hero hero)
        {
            _hero.ReplaceOne(hero => hero.Id == id, hero);
        }
    }
}
