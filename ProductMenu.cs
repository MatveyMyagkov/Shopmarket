public class ProductMenu: ProductService
{
    public void ShowCatalog(User user)
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("В каталоге пока нет товаров");
        }
        else
        {
            foreach (Product currentProduct in _products)
            {
                Console.WriteLine($"Товар ID({currentProduct.Id}): {currentProduct.Name}");
                Console.WriteLine($"Краткое описание товара: {currentProduct.ShortDescription}");
                Console.WriteLine($"Цена: {currentProduct.Price}$\n");
            }



            Console.WriteLine("Что вы хотите сделать с товароми\n0 - Выйти из каталога\n1 - Узнать про них больше информации\n2 - Добавить товар в избранное\n3 - Удалить товар с каталого\n4 - Изменить товар\n");
            int options;
            while (!int.TryParse(Console.ReadLine(), out options) || (options != 1 && options != 0 && options != 2 && options != 3 && options != 4))
            {
                Console.WriteLine("Пожалуйста, введите число 0, 1, 2, 3 или 4");
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
                    break;
                case 3:
                    Console.WriteLine("Какой товар вы бы хотели добавить в избранное? (Введите ID товара)");
                    int _number2;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out _number2) && _number2 > 0 && _number2 <= _products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");

                    }
                    DeleteProduct(_products, _number2);
                    break;
                case 4:
                    Console.WriteLine("Какой товар вы бы хотели добавить в избранное? (Введите ID товара)");
                    int _number3;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out _number3) && _number3 > 0 && _number3 <= _products.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Введите Id существующего товара");

                    }
                    AlterProduct(_products, _number3);
                    break;

            }
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();
        var backMenu = new MainMenu();
        backMenu.Show(user);
    }
}
