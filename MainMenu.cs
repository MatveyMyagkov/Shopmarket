public static class MainMenu
{
    public static void Show(User username)
    {
        Console.Clear();
        Console.WriteLine($"Пользователь: {username.Name}");
        Console.WriteLine("1: Просмотреть товары");
        Console.WriteLine("2: Добавить товар в общий каталог");
        Console.WriteLine("3: Посмотреть понравившиеся товары");
        Console.WriteLine("4: Посмотреть корзину");
        Console.WriteLine("5: Выйти из аккаунта");

        int option_in_menu;
        while (!int.TryParse(Console.ReadLine(), out option_in_menu) || option_in_menu < 1 || option_in_menu > 5)
        {
            Console.WriteLine("Пожалуйста, введите число от 1 до 4!");
            continue;
        }

        var productService = new ProductService();
        switch (option_in_menu)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Каталог товаров");
                ProductMenu.ShowCatalog(username, productService);
                break;
            case 2:
                Console.WriteLine("Давайте добавим товары");
                productService.AddProduct(username);
                break;
            case 3:
                Console.WriteLine("Избранное");
                productService.ShowSelected(username);
                break;
            case 4:
                Console.WriteLine("Корзина");
                var orderService = new OrderService();
                orderService.ShowOrder(username);
                break;
            case 5:
                var app = new UserService();
                StartMenu.Show(app);
                break;

        }
    }
}
