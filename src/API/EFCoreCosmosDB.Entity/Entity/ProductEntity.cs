using System.ComponentModel.DataAnnotations;

namespace EFCoreCosmosDB.Entity.Entity;

public class ProductEntity
{
    [Key]
    public string Id { get; set; }  // Partition key in Cosmos DB
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}
