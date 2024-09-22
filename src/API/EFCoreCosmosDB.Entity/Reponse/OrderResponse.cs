namespace EFCoreCosmosDB.Entity.Reponse;

public class OrderResponse
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
