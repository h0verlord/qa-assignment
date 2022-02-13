using OpenQA.Selenium;
using TestHelpers;

namespace PageObjects
{
    public class BasePage
    {   
        private By logoImg = By.CssSelector(".logo.img-responsive");
        private By searchForm = By.Id("searchbox");
        private By searchInput = By.Id("search_query_top");
        private By searchBtn = By.CssSelector("button.btn.btn-default.button-search");
        private By signInLink = By.CssSelector("a.login");
        private By signOutLink = By.CssSelector("a.logout");
        private By userNameLink = By.CssSelector("a.account");
        private By contactLink = By.CssSelector("#contact-link > a");

        public BasePage()
        {
            Browser.Wait.Until(e => e.FindElement(logoImg).Displayed);
        }

        /// <summary>
        /// Type given search term into search bar and press Search button
        /// </summary>
        /// <param name="keywords">search term</param>
        /// <returns>SearchResults Page</returns>
        public SearchResults SearchTerm(string keywords)
        {
            Browser.Driver.FindElement(searchInput).SendKeys(keywords);
            Browser.Driver.FindElement(searchBtn).Click();
            return new SearchResults(keywords);
        }

        /// <summary>
        /// Clicks the Sign In Button.
        /// </summary>
        /// <returns></returns>
        public SignIn ClickSignInBtn()
        {
            Browser.Driver.FindElement(signInLink).Click();
            return new SignIn();
        }

        /// <summary>
        /// Clicks the Contact Us Button
        /// </summary>
        /// <returns></returns>
        public ContactUs ClickContactUsBtn(){
            Browser.Driver.FindElement(contactLink).Click();
            return new ContactUs();
        }
    }
}