public static class MainMenu
{
    public static void Show(User username, ProductService productService, OrderService orderService, UserService userService)
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
        switch (option_in_menu)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Каталог товаров");
                ProductMenu.ShowCatalog(username, productService, orderService, userService);
                break;
            case 2:
                Console.WriteLine("Давайте добавим товары");
                productService.AddProduct(username, orderService, userService);
                break;
            case 3:
                Console.WriteLine("Избранное");
                productService.ShowSelected(username, orderService, userService);
                break;
            case 4:
                Console.WriteLine("Корзина");
                orderService.ShowOrder(username, productService, userService);
                break;
            case 5:
                StartMenu.Show(userService, productService, orderService);
                break;

        }
    }
}
