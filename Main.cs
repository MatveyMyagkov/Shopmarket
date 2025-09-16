class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> users_direct = new Dictionary<string, string>();
        var app = new Register(users_direct);
        app.Run();
    }
}