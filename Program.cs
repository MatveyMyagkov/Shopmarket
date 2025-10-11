class Program
{
    static void Main(string[] args)
    {
        var userService = new UserService();
        var collections = CreateCollections.Instance;
        StartMenu.Show(userService);
    }
}