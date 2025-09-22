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
            var menu = new MainMenu();
            menu.Show(user);
        }
        else
        {
            Console.WriteLine("Неверно введен имя пользователя или пароль");
            var app = new UserService();
            StartMenu.Show(app);

        }
    }

    public void ShowSuccessMessage(User currentUser)
    {
        var menu = new MainMenu();
        menu.Show(currentUser);
    }
}



