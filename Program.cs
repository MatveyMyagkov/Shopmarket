class Program
{
    static void Main(string[] args)
    {
        var userService = new UserService();
        StartMenu.Show(userService);
    }
}