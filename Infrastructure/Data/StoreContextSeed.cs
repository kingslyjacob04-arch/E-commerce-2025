using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
  public static async Task SeedAsync(StoreContext context)
  {
    try
    {
      var existing = context.Products.Any();
      Console.WriteLine($"StoreContextSeed: Products table has rows: {existing}");

      if (!existing)
      {
        var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

        var products = JsonSerializer.Deserialize<List<Product>>(productsData, new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true
        });

        if (products == null)
        {
          Console.WriteLine("StoreContextSeed: No products found in JSON file.");
          return;
        }

        Console.WriteLine($"StoreContextSeed: Seeding {products.Count} products...");
        context.Products.AddRange(products);

        var saved = await context.SaveChangesAsync();
        Console.WriteLine($"StoreContextSeed: SaveChangesAsync returned {saved}.");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"StoreContextSeed error: {ex}");
      throw;
    }
  }
}
