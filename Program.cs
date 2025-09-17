public class Product
{
    public string Name { get; set; }
    public string Short_Description { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Product(string name, string short_description, string description, decimal price)
    {
        Name = name;
        Short_Description = short_description;
        Description = description;
        Price = price;
    }
}
public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public List<Product> Products { get; set; }

    public User()
    {
        Products = new List<Product>();
    }
}