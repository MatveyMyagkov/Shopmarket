public class MainMenu
{
    public void Show(User username)
    {
        Console.Clear();
        Console.WriteLine($"Пользователь: {username.Name}");
        Console.WriteLine("1: Просмотреть товары");
        Console.WriteLine("2: Добавить товар в общий каталог");
        Console.WriteLine("3: Посмотреть понравившиеся товары");
        Console.WriteLine("4: Выйти из аккаунта");

        int option_in_menu;
        while (!int.TryParse(Console.ReadLine(), out option_in_menu) || (option_in_menu != 1 && option_in_menu != 2 && option_in_menu != 3 && option_in_menu != 4))
        {
            Console.WriteLine("Пожалуйста, введите число(1 или 2 или 3 или 4)!");
            continue;
        }
        var productService = new ProductMenu();
        switch (option_in_menu)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Каталог товаров");
                productService.ShowCatalog(username);
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
                var app = new UserService();
                StartMenu.Show(app);
                break;

        }
    }
}
