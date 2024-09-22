namespace EFCoreCosmosDB.Entity.Request;

public class OrderRequest
{
    public string UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
