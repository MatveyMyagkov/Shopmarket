public class OrderService
{

    public void AddOrder(User user)
    {

        Console.WriteLine("Введите ID товара, который вы бы хотели добавить в корзины");
        int options;
        while (!int.TryParse(Console.ReadLine(), out options))
        {
            Console.WriteLine("Введите ID товара");
        }

        var productRemove = user.Products.FirstOrDefault(p => p.Id == options);
        if (productRemove != null)
        {
            user.Order.Add(productRemove);
            Console.WriteLine("Товар успешно добавлен в корзину");
        }
        else
        {
            Console.WriteLine("Товар с указанным ID не найден в избранном");
        }
    }

    public void ShowOrder(User user)
    {
        Console.Clear();
        if (user.Order.Count == 0)
        {
            Console.WriteLine("У вас нет товаров в корзине");
        }
        else
        {
            Console.WriteLine("Понравившиеся товары");
            foreach (var product in user.Order)
            {
                Console.WriteLine($"Товар ID({product.Id}): {product.Name}");
                Console.WriteLine($"Краткое описание товара: {product.ShortDescription}");
                Console.WriteLine($"Полное описание товара: {product.Description}");
                Console.WriteLine($"Цена: {product.Price}");
            }

            Console.WriteLine("0 - Вернуться на главную");
            Console.WriteLine("1 - Удалить товар из корзины");
            int options;
            while (!int.TryParse(Console.ReadLine(), out options) || options < 0 || options > 1)
            {
                Console.WriteLine("Введите число 0 или 1");
            }
            switch (options)
            {
                case 0:
                    MainMenu.Show(user);
                    break;

                case 1:
                    DeleteProductOrder(user);
                    break;
            }
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
        Console.ReadLine();

        MainMenu.Show(user);
    }
    private void DeleteProductOrder(User user)
    {
        Console.WriteLine("Введите ID товара, который вы бы хотели удалить из корзины");
        int options;
        while (!int.TryParse(Console.ReadLine(), out options))
        {
            Console.WriteLine("Введите ID товара");
        }

        var productRemove = user.Order.FirstOrDefault(p => p.Id == options);
        if (productRemove != null)
        {
            user.Order.Remove(productRemove);
            Console.WriteLine("Товар успешно удален из корзины");
        }
        else
        {
            Console.WriteLine("Товар с указанным ID не найден в корзине");
        }
    }
}