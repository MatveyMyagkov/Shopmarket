public class Menu
{
    public void Run_Menu(User username, Dictionary<string, List<object>> users_direct)
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
                Show_user_product(username, users_direct);
                break;
            case 2:
                Console.WriteLine("Давай авторизуемся");
                break;
            case 3:
                var app = new Register(users_direct);
                app.Run();
                break;

        }
    }
    private void Show_user_product(User user, Dictionary<string, List<object>> users_direct)
    {
        if (user.Products.Count == 0)
        {
            Console.WriteLine("У вас пока нет товаров");
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться на главную");
            Console.ReadLine();
            Run_Menu(user, users_direct);
            return;
        }
    }

    
}
