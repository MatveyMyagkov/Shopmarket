using static System.Runtime.InteropServices.JavaScript.JSType;

public class ProductMenu
{
    private static List<Product> _products = new List<Product>();
    private static int ID = 1;
    public ProductMenu()
    {

    }
    public void ShowCatalog(User user)
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("В каталоге пока нет товаров");
        }
        else
        {
            int currentNumber = 1;
            foreach (Product currentProduct in _products)
            {
                Console.WriteLine($"Товар ID({currentNumber}): {currentProduct.Name}");
                Console.WriteLine($"Краткое описание товара: {currentProduct.ShortDescription}");
                Console.WriteLine($"Цена: {currentProduct.Price}$\n");
                currentNumber++;
            }



            Console.WriteLine("Что вы хотите сделать с товароми\n0 - Выйти из каталога\n1 - Узнать про них больше информации\n2 - Добавить товар в избранное");
            int options;
            while (!int.TryParse(Console.ReadLine(), out options) || (options != 1 && options != 0 && options != 2))
            {
                Console.WriteLine("Пожалуйста, введите число 0 или 1 или 2");
                continue;
            }
            switch (options)
            {
                case 0:
                    var backMenu1 = new MainMenu();
                    backMenu1.Show(user);
                    break;
                case 1:
                    Console.WriteLine("Какой товар вы бы хотели просмотреть полностью? (Введите ID товара)");
                    int number;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number <= _products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");

                    }
                    ShowFullProduct(user, number);
                    break;
                case 2:
                    Console.WriteLine("Какой товар вы бы хотели добавить в избранное? (Введите ID товара)");
                    int _number;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out _number) && _number > 0 && _number <= _products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");

                    }
                    user.Products.Add(_products[_number - 1]);
                    Console.WriteLine("Товар успешно добавлен!");
                    Thread.Sleep(1000);
                    break;


            }
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();
        var backMenu = new MainMenu();
        backMenu.Show(user); 
    }


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
        var product = new Product(ID, nameProduct, shortDescription, description, price);
        ID++;
        _products.Add(product);
        Console.WriteLine("Товар усспешно добавлен!");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();
        var backMenu = new MainMenu();
        backMenu.Show(user);
        return;

    }
    private void ShowFullProduct(User user, int number)
    {
        Console.Clear();
        Console.WriteLine($"Товар {number}: {_products[number - 1].Name}");
        Console.WriteLine($"Краткое описание товара: {_products[number - 1].ShortDescription}");
        Console.WriteLine($"Полное описание товара: {_products[number - 1].Description}");
        Console.WriteLine($"Цена: {_products[number - 1].Price}\n");
        Console.WriteLine("Хотите добавить в избранное этот товар?\n0 - Вернуться на главную\n1 - Добавить в избранное\n");
        int option;
        while(!int.TryParse(Console.ReadLine(), out option) || (option != 0 && option != 1))
        {
            Console.WriteLine("Введите число 0 или 1!");
        }
        switch(option)
        {
            case 0:
                
                break;
            case 1:
                user.Products.Add(_products[number - 1]);
                Console.WriteLine("Товар успешно добавлен!");
                Thread.Sleep(1000);
                break;
        }
        var backMenu = new MainMenu();
        backMenu.Show(user);
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
            int k = 1;
            foreach (var product in user.Products)
            {
                Console.WriteLine($"Товар {k}: {product.Name}");
                Console.WriteLine($"Краткое описание товара: {product.ShortDescription}");
                Console.WriteLine($"Полное описание товара: {product.Description}");
                Console.WriteLine($"Цена: {product.Price}\n");
                k++;

            }

            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
            Console.ReadLine();
            
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();
        var backMenu = new MainMenu();
        backMenu.Show(user);
    }
}
