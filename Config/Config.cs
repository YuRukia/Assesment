namespace Config;

public class Configuration : AppSettings
{
        private static AppSettings appSettings = new AppSettings();
        new public static string url = appSettings.url;
        new public static string testPath = appSettings.testPath;
        new public static string defaultUser = appSettings.defaultUser;
        new public static string lockedUser = appSettings.lockedUser;
        new public static string problemUser = appSettings.problemUser;
        new public static string laggyUser = appSettings.laggyUser;
        new public static string errorUser = appSettings.errorUser;
        new public static string visualErrorUser = appSettings.visualErrorUser;
        new public static string password = appSettings.password;
        new public static Dictionary<string, Product> products = appSettings.products;
        new public static bool headless = true;
        new public static int slowmode = 0;
}