class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>();
        var users = new List<User>();

        var productService = new ProductService(products);
        var orderService = new OrderService();
        var userService = new UserService(users);

        StartMenu.Show(userService, productService, orderService);
    }
}