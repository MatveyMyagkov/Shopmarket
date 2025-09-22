public class MainMenu
{
    public void Show(User username)
    {
        Console.Clear();
        Console.WriteLine($"Пользователь: {username.Name}");
        Console.WriteLine("1: Просмотреть товары");
        Console.WriteLine("2: Добавить товар");
        Console.WriteLine("3: Выйти из аккаунта");

        int option_in_menu;
        while (!int.TryParse(Console.ReadLine(), out option_in_menu) || (option_in_menu != 1 && option_in_menu != 2 && option_in_menu != 3))
        {
            Console.WriteLine("Пожалуйста, введите число(1 или 2 или 3)!");
            continue;
        }

        switch (option_in_menu)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Ваши товары");
                Show_user_product(username);
                break;
            case 2:
                Console.WriteLine("Давайте добавим товары");
                AddProduct(username);
                break;
            case 3:
                var app = new UserService();
                StartMenu.Show(app);
                break;

        }
    }
    private void Show_user_product(User user)
    {
        if (user.Products.Count == 0)
        {
            Console.WriteLine("У вас пока нет товаров");
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
            Console.ReadLine();
            Show(user);
            return;
        }
        else
        {
            Console.WriteLine(user.Products[0].Name);
        }
    }
    private void AddProduct(User user)
    {
        Console.Clear();
        Console.WriteLine("Введите название товара");
        var nameProduct = Console.ReadLine();
        Console.WriteLine("Напишите короткое описание к вашему товару");
        var shortDescription = Console.ReadLine();
        Console.WriteLine("Напишите полное описание к вашему товару");
        var description = Console.ReadLine();
        Console.WriteLine("Введите цену вашего товара в $");
        decimal price = decimal.Parse(Console.ReadLine());
        var product = new Product(nameProduct, shortDescription, description, price);
        user.Products.Add(product);
        Console.WriteLine("Товар усспешно добавлен!");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();
        Show(user);
        return;

    }

    
}
