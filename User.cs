public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public List<Product> Products { get; set; }
    public List<Product> Order {  get; set; }

    public User()
    {
        Products = new List<Product>();
        Order = new List<Product>();
    }
}