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

    /// <summary>
    /// Clicks on COntact Us Button and Opens Contact us form.
    /// Fill in all fields and clicks SUbmit.
    /// Asserts the success message is displayed.
    /// </summary>
    [Test]
    public void TestSendValidContactForm()
    {
        var homePage = new BasePage();
        var contactUs = homePage.ClickContactUsBtn();
        contactUs.FillInFormData();
        contactUs.SubmitForm();
        Assert.IsTrue(contactUs.CheckIfSentSuccessfully());
    }

    /// <summary>
    /// Clicks on COntact Us Button and Opens Contact us form.
    /// Leaves Fields Empty and Submits the Form.
    /// Asserts Error message is displayed.
    /// </summary>
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