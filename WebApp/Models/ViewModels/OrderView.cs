namespace WebApp;

public class OrderView
{
    public int OrderID { get; set; }
    public DateOnly CreationDate { get; set; }
    public string? ClientName { get; set; }
    public string OrderStatus { get; set; } = null!;

}

public class OrderDetail
{
    public int OrderID { get; set; }
    public string OrderStatus { get; set; } = null!;
    public string? ClientName { get; set; }
    public string? ClientPhone { get; set; }
    public string? Address { get; set; }
    public string? Location { get; set; }
}

public class OrderCreation
{
    public string? ClientName { get; set; }
    public int OrderStatusID { get; set; }
}