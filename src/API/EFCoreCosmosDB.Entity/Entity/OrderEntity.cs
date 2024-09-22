using System.ComponentModel.DataAnnotations;

namespace EFCoreCosmosDB.Entity.Entity;

public class OrderEntity
{
    [Key]
    public string Id { get; set; }  // Partition key in Cosmos DB
    public string UserId { get; set; }  // Reference to User Id (if needed)
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
