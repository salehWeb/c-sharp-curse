﻿namespace WebApplication1.Models
{
    public class SuperHeroDatabaseSettings : ISuperHeroDatabaseSettings
    {
       public string ConnectionString { get; set; } = "";
       public string DatabaseName { get; set; } = "";
       public string HerosCollectionName { get; set; } = "";
    }
}
