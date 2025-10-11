public static class ProductMenu
{
    public static void ShowCatalog(User user, ProductService productService)
    {
        if (productService.Products.Count == 0)
        {
            Console.WriteLine("В каталоге пока нет товаров");
        }
        else
        {
            foreach (Product currentProduct in productService.Products)
            {
                Console.WriteLine($"Товар ID({currentProduct.Id}): {currentProduct.Name}");
                Console.WriteLine($"Краткое описание товара: {currentProduct.ShortDescription}");
                Console.WriteLine($"Цена: {currentProduct.Price}$");
            }

            Console.WriteLine("Что вы хотите сделать с товароми");
            Console.WriteLine("0 - Выйти из каталога");
            Console.WriteLine("1 - Узнать про них больше информации");
            Console.WriteLine("2 - Добавить товар в избранное");
            Console.WriteLine("3 - Добавить товар в корзину");
            Console.WriteLine("4 - Удалить товар с каталогa");
            Console.WriteLine("5 - Изменить товар");
            int options;
            while (!int.TryParse(Console.ReadLine(), out options) || options < 0 || options > 5)
            {
                Console.WriteLine("Пожалуйста, введите число от 0, 1, 2, 3 или 4");
            }

            switch (options)
            {
                case 0:
                    MainMenu.Show(user);
                    break;
                case 1:
                    Console.WriteLine("Какой товар вы бы хотели просмотреть полностью? (Введите ID товара)");
                    int number;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number <= productService.Products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");

                    }

                    productService.ShowFullProduct(user, number);
                    break;
                case 2:
                    Console.WriteLine("Какой товар вы бы хотели добавить в избранное? (Введите ID товара)");
                    int _number;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out _number) &&
                            _number > 0 &&
                            _number <= productService.Products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");

                    }
                    user.Products.Add(productService.Products.ElementAt(_number - 1));
                    Console.WriteLine("Товар успешно добавлен!");
                    break;
                case 3:
                    Console.WriteLine("Какой товар вы бы хотели добавить в корзину? (Введите ID товара)");
                    int _number1;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out _number1) &&
                            _number1 > 0 &&
                            _number1 <= productService.Products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");
                    }
                    user.Order.Add(productService.Products.ElementAt(_number1 - 1));
                    Console.WriteLine("Товар успешно добавлен!");
                    break;
                case 4:
                    Console.WriteLine("Какой товар вы бы хотели удалить из корзины? (Введите ID товара)");
                    int _number2;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out _number2) && _number2 > 0 && _number2 <= productService.Products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");

                    }
                    productService.DeleteProduct(_number2);
                    break;
                case 5:
                    Console.WriteLine("Какой товар вы бы хотели добавить в избранное? (Введите ID товара)");
                    int _number3;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out _number3) && _number3 > 0 && _number3 <=productService.Products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");

                    }
                    productService.AlterProduct(_number3);
                    break;

            }
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();
        MainMenu.Show(user);
    }
}
