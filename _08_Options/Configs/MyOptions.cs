namespace _08_Options.Configs;

public class MyOptions
{
    public string Name { get; set; } = "default";

    public int Age { get; set; } = 0;

    public string Address { get; set; } = "China";

    public SubOption SubOption1 { get; set; }

    public SubOption SubOption2 { get; set; }
}