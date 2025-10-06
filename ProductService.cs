public class ProductService
{
    private static List<Product> _products = new List<Product>();

    public IReadOnlyCollection<Product> Products => _products;

    public void AddProduct(User user)
    {
        Console.Clear();
        Console.WriteLine("Введите название товара");
        var nameProduct = Console.ReadLine();

        Console.WriteLine("Напишите короткое описание к вашему товару");
        var shortDescription = Console.ReadLine();

        Console.WriteLine("Напишите полное описание к вашему товару");
        var description = Console.ReadLine();

        Console.WriteLine("Введите цену вашего товара в $");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Пожалуйста введите число (Не обязательно целое)");
        }

        var newId = _products.Count + 1;
        var product = new Product(newId, nameProduct, shortDescription, description, price);
        _products.Add(product);

        Console.WriteLine("Товар усспешно добавлен!");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();

        MainMenu.Show(user);
    }

    public void ShowSelected(User user)
    {
        Console.Clear();
        if (user.Products.Count == 0)
        {
            Console.WriteLine("Ваша корзина пуста");
        }
        else
        {
            Console.WriteLine("Ваша корзина");
            foreach (var product in user.Products)
            {
                Console.WriteLine($"Товар ID({product.Id}): {product.Name}");
                Console.WriteLine($"Краткое описание товара: {product.ShortDescription}");
                Console.WriteLine($"Полное описание товара: {product.Description}");
                Console.WriteLine($"Цена: {product.Price}");
            }

            Console.WriteLine("0 - Вернуться на главную");
            Console.WriteLine("1 - Удалить товар по ID");
            int options;
            while (!int.TryParse(Console.ReadLine(),out options) || (options != 0 && options != 1))
            {
                Console.WriteLine("Введите число 0 или 1");
            }
            switch (options)
            {
                case 0:
                    MainMenu.Show(user);
                    break;
                    
                case 1:
                    DeleteProductCatalog(user);
                    break;
            }
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();

        MainMenu.Show(user);
    }

    public void ShowFullProduct(User user, int number)
    {
        Console.Clear();
        Console.WriteLine($"Товар ID({number}): {_products[number - 1].Name}");
        Console.WriteLine($"Краткое описание товара: {_products[number - 1].ShortDescription}");
        Console.WriteLine($"Полное описание товара: {_products[number - 1].Description}");
        Console.WriteLine($"Цена: {_products[number - 1].Price}\n");

        Console.WriteLine("Хотите добавить в избранное этот товар?");
        Console.WriteLine("0 - Вернуться на главную");
        Console.WriteLine("1 - Добавить в избранное");
        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || (option != 0 && option != 1))
        {
            Console.WriteLine("Введите число 0 или 1!");
        }

        switch (option)
        {
            case 0:

                break;
            case 1:
                user.Products.Add(_products[number - 1]);
                Console.WriteLine("Товар успешно добавлен!");
                Thread.Sleep(1000);
                break;
        }

        MainMenu.Show(user);
    }

    private void DeleteProductCatalog(User user)
    {
        Console.WriteLine("Введите ID товара, который вы бы хотели удалить из корзины");
        int options;
        while (!int.TryParse(Console.ReadLine(), out options))
        {
            Console.WriteLine("Введите ID товара");
        }

        var productRemove = user.Products.FirstOrDefault(p => p.Id == options);
        if (productRemove != null)
        {
            user.Products.Remove(productRemove);
            Console.WriteLine("Товар успешно удален из корзины");
        }
        else
        {
            Console.WriteLine("Товар с указанным ID не найден в корзине");
        }
    }
    public void DeleteProduct(int id)
    {
        var productDelete = _products.FirstOrDefault(p => p.Id == id);
        if (productDelete != null)
        {
            _products.Remove(productDelete);
            Console.WriteLine("Товар успешно удален из каталога");
        }
        else
        {
            Console.WriteLine("Товар с указанным ID не найден в каталоге");
        }

    }

    public void AlterProduct(int id)
    {
        var productChange = _products.FirstOrDefault(p => p.Id == id);
        if (productChange != null)
        {
            Console.Clear();
            Console.WriteLine($"Товар ID({productChange.Id}): {productChange.Name}");
            Console.WriteLine($"Краткое описание товара: {productChange.ShortDescription}");
            Console.WriteLine($"Полное описание товара: {productChange.Description}");
            Console.WriteLine($"Цена: {productChange.Price}\n");
            Console.WriteLine("Какую характеристику товара вы хотели бы изменить?\n0 - Вернуться на главную\n1 - Название товара\n2 - Краткое описание товара\n3 - Полное описание товара\n4 - Цену товара\n");
        }
        else
        {
            Console.WriteLine("Товар с указанным ID не найден в каталоге");
        }

        int option;
        int.TryParse(Console.ReadLine(), out option);

        Console.WriteLine("Введите число от 1 до 4!");

        switch (option)
        {
            case 1:
                Console.WriteLine("Введите новове название товара: ");
                var name = Console.ReadLine();
                productChange.Name = name;
                break;
            case 2:
                Console.WriteLine("Введите новове краткое описание товара: ");
                var shortDescription = Console.ReadLine();
                productChange.ShortDescription = shortDescription;
                break;
            case 3:
                Console.WriteLine("Введите новове полное описание товара: ");
                var description = Console.ReadLine();
                productChange.ShortDescription = description;
                break;
            case 4:
                Console.WriteLine("Введите цену вашего товара в $");
                decimal price;
                while (!decimal.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Пожалуйста введите число (Не обязательно целое)");
                }
                productChange.Price = price;
                break;
            default:
                Console.WriteLine("Вы ввели число не из диапазона от (1 до 4)");
                Console.ReadKey();
                break;
        }
    }
}