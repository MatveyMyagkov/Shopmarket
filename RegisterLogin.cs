public class Register(Dictionary<string, string> users_direct)
{
    private User currentUser;

    public void Run()
    {
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
                Registed();
                break;
            case 2:
                Console.WriteLine("Давай авторизуемся");
                Login();
                break;



        }
    }

    public void Registed()
    {
        Console.Write("Введите имя пользователя: ");
        var username = Console.ReadLine();

        if (users_direct.ContainsKey(username))
        {
            Console.WriteLine("Пользователь с таким именем уже существует!");
            return;
        }

        Console.Write("Введите пароль: ");
        var password = Console.ReadLine();

        users_direct[username] = password;

        currentUser = new User
        {
            Name = username,
            Password = password
        };

        Console.WriteLine("Регистрация успешна!");
        ShowSuccessMessage(currentUser, users_direct);
    }

    public void Login()
    {
        Console.Clear();
        Console.WriteLine("Введите имя пользователя: ");
        string login_user = Console.ReadLine();
        if (users_direct.ContainsKey(login_user))
        {
            Console.WriteLine("Введите пароль: ");
            string Login_password = Console.ReadLine();
            if (Login_password == users_direct[login_user])
            {
                var menu = new Menu();
                menu.Run_Menu(currentUser, users_direct);
            }
        }
    }

    public void ShowSuccessMessage(User currentUser, Dictionary<string, string> users_direct)
    {
        var menu = new Menu();
        menu.Run_Menu(currentUser, users_direct);
    }
}



