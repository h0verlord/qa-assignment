using NUnit.Framework;
using TestHelpers;
using PageObjects;

public class ContactUsTest
{
    [OneTimeSetUp]
    public void Setup()
    {
        Browser.CreateDriver();
        Generators.CreateGenerators();
        Browser.NavigateTo();
    }

    
    [Test]
    public void TestSendValidContactForm()
    {
        var homePage = new BasePage();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Browser.Driver.Close();
        Browser.Driver.Quit();
    }
}