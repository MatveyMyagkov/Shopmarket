public class Product
{
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Product(string name, string short_description, string description, decimal price)
    {
        Name = name;
        ShortDescription = short_description;
        Description = description;
        Price = price;
    }
}
