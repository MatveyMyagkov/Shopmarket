using System.Runtime.CompilerServices;

public class Menu()
{
    public void Run()
    {
        Console.WriteLine("Добро пожаловать в магазин");
        var New_User = new User();
        bool flag = true;
        int option;
        Console.WriteLine("Главное меню");
        Console.WriteLine("1: Зарегистрироваться");
        Console.WriteLine("2: Вход в аккаунт");
        Console.WriteLine("3: Выйти из приложения");
        option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 0:
                flag = false;
                break;
            case 1:
                Console.WriteLine("Давай зарегистрируемся");
                Dictionary<string, string> users_direct = new Dictionary<string, string> {};
                Register(users_direct);
                foreach (KeyValuePair<string, string> pair in users_direct)
                {
                    Console.WriteLine($"Ваше имя: {pair.Key}, Пароль: {pair.Value}");
                }
                break;
            case 2:
                Console.WriteLine("Давай авторизуемся");
                break;
        }
        Console.WriteLine("");
    }
    private void Register(Dictionary<string, string> data)
    {
        Console.Write("Введите имя пользователя: ");
        var username = Console.ReadLine();

        Console.Write("Введите пароль: ");
        var password = Console.ReadLine();
        var New_User = new User();
        New_User.Name = username;
        New_User.Password = password;
        data[username] = password;



    }

}
