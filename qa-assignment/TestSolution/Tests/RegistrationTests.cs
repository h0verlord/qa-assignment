using NUnit.Framework;
using TestHelpers;
using PageObjects;

public class RegistrationTest
{
    [OneTimeSetUp]
    public void Setup()
    {
        Browser.CreateDriver();
        Generators.CreateGenerators();
        Browser.NavigateTo();
    }

    [Test]
    public void TestEmptyEmailAddress()
    {
        var homePage = new BasePage();
        var signInPage = homePage.ClickSignInBtn();
        signInPage.FillEmailCreateForm("");
        Assert.IsTrue(signInPage.CheckIfErrorIsDisplayed, "Error not displayed after timeout.");
    }

    [Test]
    public void TestInvalidEmailAddress()
    {
        var homePage = new BasePage();
        var signInPage = homePage.ClickSignInBtn();
        signInPage.FillEmailCreateForm(false);
        Assert.IsTrue(signInPage.CheckIfErrorIsDisplayed, "Error not displayed after timeout.");
    }

    [Test]
    public void TestRegisterValidEmailAddress()
    {
        var homePage = new BasePage();
        var signInPage = homePage.ClickSignInBtn();
        signInPage.FillEmailCreateForm(true);
        var registration = new RegistrationPage();
        registration.FillMandatoryFields();
        var accountPage = registration.SubmitCreateAccountForm();
        Assert.IsTrue(accountPage.VerifyMyAccountIsOpened(), "MyAccount Page not opened after registration.");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Browser.Driver.Close();
        Browser.Driver.Quit();
    }
}