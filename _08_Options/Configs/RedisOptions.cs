namespace _08_Options.Configs;

public class RedisOptions
{
    public string Host { get; set; } = "127.0.0.1";

    public int Port { get; set; } = 6073;

    public string UserName { get; set; } = "root";

    public string Password { get; set; } = string.Empty;
}