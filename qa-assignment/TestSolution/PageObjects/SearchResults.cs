using OpenQA.Selenium;
using PageObjects;
using TestHelpers;

namespace PageObjects
{

    public class SearchResults : BasePage
    {
        string searchTerm { get; set; }

        public By searchResultHeader = By.TagName("h1");
        public By searchResultContent = By.CssSelector("p.alert");
        public SearchResults(string keywords) => this.searchTerm = keywords;
        public bool SearchTermAssert => Browser.Driver.FindElement(searchResultContent).Text.Contains(searchTerm);
        public bool EmptySearchTermAssert => Browser.Driver.FindElement(searchResultContent).Text.Equals("Please `enter a search keyword");
    }
}