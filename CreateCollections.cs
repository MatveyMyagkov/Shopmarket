public class CreateCollections
{   public List<User> Users { get; private set; }
    private List<Product> _products;
    public IReadOnlyList<Product> Products => _products.AsReadOnly();

    private static CreateCollections _instance;
    public static CreateCollections Instance => _instance;

    static CreateCollections()
    {
        _instance = new CreateCollections();
    }

    private CreateCollections()
    {
        Users = new List<User>();
        _products = new List<Product>();
    }

    public void AddProduct(Product product) => _products.Add(product);
    public void RemoveProduct(Product product) => _products.Remove(product);
}
