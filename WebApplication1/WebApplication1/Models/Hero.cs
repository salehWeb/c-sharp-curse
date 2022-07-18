using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models;

public class Hero
{
    [BsonId]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = "";

    [BsonElement("place")]
    public string Place { get; set; } = "";

    [BsonElement("firs-name")]
    public string FirstName { get; set; } = "";

    [BsonElement("last-name")]
    public string LastName { get; set; } = "";
}