using System.ComponentModel.DataAnnotations;

namespace EFCoreCosmosDB.Entity.Entity;

public class UserEntity
{
    /// <summary>
    /// Partition key in Cosmos DB
    /// </summary>
    [Key]
    public string Id { get; set; } 
    public string Name { get; set; }
    public string Email { get; set; }
}
