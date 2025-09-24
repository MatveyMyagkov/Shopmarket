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
        }
        else
        {
            int currentNumber = 1;
            foreach (Product currentProduct in user.Products)
            {
                Console.WriteLine($"Товар {currentNumber}: {currentProduct.Name}");
                Console.WriteLine($"Краткое описание товара: {currentProduct.ShortDescription}");
                Console.WriteLine($"Цена: {currentProduct.Price}\n");
                currentNumber++;
            }



            Console.WriteLine("Что вы хотите сделать с товароми\n 1 - Узнать про них больше информации\n 0 - Выйти из товаров");
            int options;
            while (!int.TryParse(Console.ReadLine(), out options) || (options != 1 && options != 0))
            {
                Console.WriteLine("Пожалуйста, введите число 0 или 1");
                continue;
            }
            switch (options)
            {
                case 0:
                    Show(user);
                    break;
                case 1:
                    Console.WriteLine("Какой товар вы бы хотели просмотреть полностью? (Введите номер товара)");
                    int number;
                    while (true){
                        if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number <= user.Products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите номер существующего товара");
                            
                    }
                    ShowFullProduct(user, number);
                    break;


            }
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();
        Show(user);
        return;
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
    private void ShowFullProduct(User user, int number)
    {
        Console.Clear();
        Console.WriteLine($"Товар {number}: {user.Products[number - 1].Name}");
        Console.WriteLine($"Краткое описание товара: {user.Products[number - 1].ShortDescription}");
        Console.WriteLine($"Полное описание товара: {user.Products[number - 1].Description}");
        Console.WriteLine($"Цена: {user.Products[number - 1].Price}\n");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();
        Show(user);
        return;
    }


}
