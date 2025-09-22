using System;

public static class StartMenu
{
    public static void Show(UserService userService)
    {
        Console.Clear();
        Console.WriteLine("Добро пожаловать в наш магазин!");
        Console.WriteLine("1: Зарегистрироваться");
        Console.WriteLine("2: Вход в аккаунт");
        Console.Write("Выберите опцию: ");

        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
        {
            Console.WriteLine("Пожалуйста, введите число(1 или 2)!");
            continue;
        }

        switch (option)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Давай зарегистрируемся");
                userService.Register();
                break;
            case 2:
                Console.WriteLine("Давай авторизуемся");
                userService.Login();
                break;
        }
    }
}
