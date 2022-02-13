using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using TestHelpers;

public class Registration
{

    #region Personal Info Elements
    private By accountCreate = By.ClassName("account_creation");
    private By genderInputs = By.Name("id_gender");
    private By firstNameCustInput = By.Id("customer_firstname");
    private By lastNameCustInput = By.Id("customer_lastname");
    private By emailInput = By.Id("email");
    private By passwordInput = By.Id("passwd");
    private By daySelectEl = By.Id("days");
    private By monthSelectEl = By.Id("months");
    private By yearSelectEl = By.Id("years");
    private By newsCheckbox = By.Id("newsletter");
    private By optinCheckbox = By.Id("optin");
    #endregion

    #region Your Address Elements
    private By firstNameInput = By.Id("firstname");
    private By lastNameInput = By.Id("lastname");
    private By addressInput = By.Id("address1");
    private By cityInput = By.Id("city");
    private By stateSelectEl = By.Id("id_state");
    private By stateSelectElCollection = By.CssSelector("select#id_state > option");
    private By postcodeInput = By.Id("postcode");
    private By countrySelectEl = By.Id("id_country");
    private By mobileInput = By.Id("phone_mobile");
    private By addressAliasInput = By.Id("alias");
    #endregion

    private By fieldErrors = By.ClassName("inline-infos");
    private By dataAlerts = By.CssSelector("div.alert.alert-danger");
    private By registerBtn = By.Id("submitAccount");

    public Registration()
    {
        Browser.Wait.Until(e => e.FindElement(stateSelectEl));
    }

    /// <summary>
    /// Clicks on a Register Button.
    /// </summary>
    /// <returns>This Registration Page</returns>
    public MyAccount SubmitCreateAccountForm()
    {
        Browser.Driver.FindElement(registerBtn).Click();
        return new MyAccount();
    }

    /// <summary>
    /// Fills In all Mandatory Fields in Registration Form.
    /// </summary>
    /// <returns></returns>
    public Registration FillMandatoryFields()
    {
        // Choose Gender
        Browser.Driver.FindElements(genderInputs).First().Click();
        // Enter First and Last name
        Browser.Driver.FindElement(firstNameCustInput).SendKeys("John");
        Browser.Driver.FindElement(lastNameCustInput).SendKeys("Doe");
        // Choose Password
        Browser.Driver.FindElement(passwordInput).SendKeys("test123");
        // Choose Date of Birth / NON MANDATORY
        var daySelect = new SelectElement(Browser.Driver.FindElement(daySelectEl));
        var monthSelect = new SelectElement(Browser.Driver.FindElement(monthSelectEl));
        var yearSelect = new SelectElement(Browser.Driver.FindElement(yearSelectEl));
        daySelect.SelectByIndex(1);
        monthSelect.SelectByIndex(1);
        yearSelect.SelectByIndex(1);
        // Enter Address Info, first, last name
        Browser.Driver.FindElement(addressInput).SendKeys("123");
        // Enter a city name
        Browser.Driver.FindElement(cityInput).SendKeys("Prague");
        // Select a state from dropdown / Alabama
        var stateSelect = WaitUntilStatesLoad();
        stateSelect.SelectByIndex(Generators.Rng.Next(1, stateSelect.Options.Count)-1);
        // Enter Postcode
        Browser.Driver.FindElement(postcodeInput).SendKeys("12345");
        // Select Country from dropdown / United States
        var countrySelect = new SelectElement(Browser.Driver.FindElement(countrySelectEl));
        countrySelect.SelectByIndex(1);
        // Enter a Phone Number
        Browser.Driver.FindElement(mobileInput).SendKeys("123456789");
        // Enter Address Alias
        return this;
    }

    /// <summary>
    /// Waits until Elements in the select dropdown input are at least 3
    /// and then returns new Select Element. 
    /// Sometimes having problems with States dropdown select input field.
    /// </summary>
    /// <returns></returns>
    public SelectElement WaitUntilStatesLoad()
    {
        Browser.Wait.Until(e => e.FindElements(stateSelectElCollection).ToList().Count > 2);
        return new SelectElement(Browser.Driver.FindElement(stateSelectEl));
    }

}