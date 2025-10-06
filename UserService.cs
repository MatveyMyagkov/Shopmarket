public class UserService
{
    private User _currentUser;
    private static List<User> _users = new List<User>();
    public UserService()
    {

    }

    public void Register()
    {
        Console.Write("Введите имя пользователя: ");
        var username = Console.ReadLine();

        //if (_users.FirstOrDefault(o => o.Name == username) is not null)
        if (_users.Any(o => o.Name == username))
        {
            Console.WriteLine("Пользователь с таким именем уже существует!");
            return;
        }

        Console.Write("Введите пароль: ");
        var password = Console.ReadLine();
        Console.WriteLine("Введите повторно пароль: ");
        var passwordConfirm = Console.ReadLine();
        while (passwordConfirm != password)
        {
            Console.WriteLine("Пароли не совпадают");
            Console.Write("Введите пароль: ");
            password = Console.ReadLine();
            Console.WriteLine("Введите повторно пароль: ");
            passwordConfirm = Console.ReadLine();
        }

        _currentUser = new User
        {
            Name = username,
            Password = password
        };
        _users.Add(_currentUser);
        Console.WriteLine("Регистрация успешна!");

        ShowSuccessMessage(_currentUser);
    }

    public void Login()
    {
        Console.Clear();
        Console.WriteLine("Введите имя пользователя: ");
        var loginUser = Console.ReadLine();

        Console.WriteLine("Введите пароль: ");
        var password = Console.ReadLine();

        var user = _users.FirstOrDefault(o => o.Name == loginUser && o.Password == password.Trim());
        if (user is not null)
        {
            MainMenu.Show(user);
        }
        else
        {
            Console.WriteLine("Неверно введен пароль или имя пользователя");

            Console.WriteLine("Введите 1 - если хотите вернуться в меню");
            Console.WriteLine("2 - если хотите попробовать снова войти");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
            {
                Console.WriteLine("Пожалуйста, введите число(1 или 2)!");
                continue;
            }

            switch (option)
            {
                case 1:
                    var backMenu = new UserService();
                    StartMenu.Show(backMenu);
                    break;
                case 2:
                    var backLogin = new UserService();
                    backLogin.Login();
                    break;
            }


        }
    }

    public void ShowSuccessMessage(User currentUser)
    {
        MainMenu.Show(currentUser);
    }
}



