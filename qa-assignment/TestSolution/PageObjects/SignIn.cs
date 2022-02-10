using OpenQA.Selenium;
using PageObjects;
using TestHelpers;

public class SignIn : BasePage
{
    private By emailCreateInput = By.Id("email_create");
    private By submitCreateBtn = By.Id("SubmitCreate");
    private By formErrorBox = By.Id("create_account_error");

    private Random rng { get; set; }

    public SignIn()
    {
        rng = new Random();
        Browser.Wait.Until(e => e.FindElement(emailCreateInput).Displayed);
    }

    /// <summary>
    /// Generates email address either valid or invalid. Example: "username68@test.test"
    /// </summary>
    /// <param name="valid">If False, returns nonsense instead of email.</param>
    /// <returns>Generated email or nonsense</returns>
    private string GenerateEmailAddress(bool valid)
    {
        var randomInt = rng.Next(1000);
        if (valid)
        {
            return string.Format("{0}{1}@test.test", "username", randomInt);
        }
        else
        {
            return "dfvbjkdf1234!@#$sadf!$#@ ";
        }
    }

    /// <summary>
    /// Fills in email address and clicks submit button.
    /// </summary>
    /// <param name="email">value to be filled in email input field</param>
    /// <returns>New SignIn Page.</returns>
    public SignIn FillEmailCreateForm(string email)
    {
        Browser.Driver.FindElement(emailCreateInput).SendKeys(email);
        Browser.Driver.FindElement(submitCreateBtn).Click();
        return this;
    }

    /// <summary>
    /// Fills in valid/invalid generated email address and clicks submit button.
    /// </summary>
    /// <param name="valid">Sazs whethet the email should be valid or invalid.</param>
    /// <returns>New SignIn Page.</returns>
    public SignIn FillEmailCreateForm(bool valid = true)
    {
        var email = GenerateEmailAddress(valid);
        Browser.Wait.Until(e => e.FindElement(emailCreateInput).Displayed);
        Browser.Driver.FindElement(emailCreateInput).SendKeys(email);
        Browser.Driver.FindElement(submitCreateBtn).Click();
        return this;
    }

    /// <summary>
    /// Waits for error box to be displayed.
    /// </summary>
    public bool CheckIfErrorIsDisplayed => Browser.Wait.Until(e => e.FindElement(formErrorBox).Displayed);
}