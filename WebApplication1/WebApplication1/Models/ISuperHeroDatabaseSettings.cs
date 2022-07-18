namespace WebApplication1.Models
{
    public interface ISuperHeroDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string HerosCollectionName { get; set; }
    }
}
