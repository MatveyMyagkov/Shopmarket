class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<object>> users_direct = new Dictionary<string, List<object>>();
        var app = new Register(users_direct);
        app.Run();
    }
}