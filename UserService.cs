public class UserService
{
    private User _currentUser;
    private readonly List<User> _users;

    public UserService(List<User> users)
    {
        _users = users;
    }



    public void Register(ProductService productService, OrderService orderService)
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

        ShowSuccessMessage(_currentUser, productService, orderService);
    }

    public void Login(ProductService productService, OrderService orderService)
    {
        Console.Clear();
        Console.WriteLine("Введите имя пользователя: ");
        var loginUser = Console.ReadLine();

        Console.WriteLine("Введите пароль: ");
        var password = Console.ReadLine();

        var user = _users.FirstOrDefault(o => o.Name == loginUser && o.Password == password.Trim());
        if (user is not null)
        {
            MainMenu.Show(user, productService, orderService, this);
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
                    StartMenu.Show(this, productService, orderService);
                    break;
                case 2:
                    Login(productService, orderService);
                    break;
            }


        }
    }

    public void ShowSuccessMessage(User currentUser, ProductService productService, OrderService orderService)
    {
        MainMenu.Show(currentUser, productService, orderService, this);
    }
}



