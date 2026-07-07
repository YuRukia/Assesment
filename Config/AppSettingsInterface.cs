using Constants;
using Microsoft.Extensions.Configuration;

namespace Config;

public class AppSettings
{
    public readonly string testPath;
    public readonly string url;
    public readonly string defaultUser;
    public readonly string lockedUser;
    public readonly string problemUser;
    public readonly string laggyUser;
    public readonly string errorUser;
    public readonly string visualErrorUser;
    public readonly string password;
    public readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

    public AppSettings()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "../../../Config/appsettings.json"))).Build();

        testPath = config.GetSection("ConfigData")["TestPath"] ?? throw new ArgumentNullException();
        url = config.GetSection("TestData")["Url"] ?? throw new ArgumentNullException();
        defaultUser = config.GetSection("TestData:Users")["Default"] ?? throw new ArgumentNullException();
        lockedUser = config.GetSection("TestData:Users")["Locked"] ?? throw new ArgumentNullException();
        problemUser = config.GetSection("TestData:Users")["Problem"] ?? throw new ArgumentNullException();
        laggyUser = config.GetSection("TestData:Users")["Laggy"] ?? throw new ArgumentNullException();
        errorUser = config.GetSection("TestData:Users")["Error"] ?? throw new ArgumentNullException();
        visualErrorUser = config.GetSection("TestData:Users")["VisualError"] ?? throw new ArgumentNullException();
        password = config.GetSection("TestData")["Password"] ?? throw new ArgumentNullException();
        
        products.Add(Products.SauceLabsBackpack,
        new Product(
            config.GetSection("TestData:Products:SauceLabsBackpack")["Name"] ?? throw new ArgumentNullException(),
            config.GetSection("TestData:Products:SauceLabsBackpack")["Price"] ?? throw new ArgumentNullException(),
            config.GetSection("TestData:Products:SauceLabsBackpack")["Description"] ?? throw new ArgumentNullException()
        ));

        products.Add(Products.SauceLabsBikeLight,
        new Product(
            config.GetSection("TestData:Products:SauceLabsBikeLight")["Name"] ?? throw new ArgumentNullException(),
            config.GetSection("TestData:Products:SauceLabsBikeLight")["Price"] ?? throw new ArgumentNullException(),
            config.GetSection("TestData:Products:SauceLabsBikeLight")["Description"] ?? throw new ArgumentNullException()
        ));
    }
}