using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestHelpers
{
    class Browser
    {
        public static IWebDriver Driver { get; set; }
        public static Actions Builder { get; set; }
        public static WebDriverWait Wait { get; set; }

        public const string HomePageUrl = "http://google.com";

        public static void CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments(string.Format("user-data-dir={0}\\ChromeProfile", GetDriverPath()));
            options.AddLocalStatePreference("acceptSslCerts", true);

            Driver = new ChromeDriver(GetDriverPath(), options);
            Builder = new Actions(Driver);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
        }

        public static string GetDriverPath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            return path.Remove(path.LastIndexOf("bin")) + "TestSolution/Driver";
        }

        public static void NaigateTo(string url = HomePageUrl, string path = "")
        {
            var urlString = string.Format("{0}/{1}", url, path);
            Browser.Driver.Navigate().GoToUrl(urlString);
        }
    }
}