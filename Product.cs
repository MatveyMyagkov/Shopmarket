public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Product(int id, string name, string short_description, string description, decimal price)
    {
        Id = id;
        Name = name;
        ShortDescription = short_description;
        Description = description;
        Price = price;
    }
}
