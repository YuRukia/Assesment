namespace Config;

public class Product
{
    public readonly string Name;
    public readonly string Cost;
    public readonly string Description;

    public Product(string Name, string Cost, string Description)
    {
        this.Name = Name;
        this.Cost = Cost;
        this.Description = Description;
    }
}