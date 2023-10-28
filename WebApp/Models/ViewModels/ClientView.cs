namespace WebApp;

public class NewClient
{
    public string Name { get; set; } = null!;
    public string Phonenumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int CompanyID { get; set; }
}

public class UpdateClient
{
    public int PersonID { get; set; }
    public string Name { get; set; } = null!;
    public string Phonenumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int ClientStatusID { get; set; }
}