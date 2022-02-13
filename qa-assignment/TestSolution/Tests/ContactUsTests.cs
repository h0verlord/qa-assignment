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
        var contactUs = homePage.ClickContactUsBtn();
        contactUs.FillInFormData();
        contactUs.SubmitForm();
        Assert.IsTrue(contactUs.CheckIfSentSuccessfully());
    }

    [Test]
    public void TestSendEmptyContactForm()
    {
        var homePage = new BasePage();
        var contactUs = homePage.ClickContactUsBtn();
        contactUs.SubmitForm();
        Assert.IsTrue(contactUs.CheckIfErrorDisplayed());
    }


    [OneTimeTearDown]
    public void TearDown()
    {
        Browser.Driver.Close();
        Browser.Driver.Quit();
    }
}