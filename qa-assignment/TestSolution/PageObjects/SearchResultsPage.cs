using OpenQA.Selenium;
using TestHelpers;
namespace PageObjects
{

    public class SearchResults : BasePage
    {
        string searchTerm { get; set; }

        public By searchResultHeader = By.TagName("h1");
        public By searchResultContent = By.CssSelector("p.alert");
        public SearchResults(string keywords) => this.searchTerm = keywords;

        /// <summary>
        /// Returns true if search result message contains the searched term.
        /// </summary>
        public bool SearchTermAssert => Browser.Driver.FindElement(searchResultContent).Text.Contains(searchTerm);

        /// <summary>
        /// Returns true if the search warning equals 'Please enter a search keyword'.
        /// </summary>
        public bool EmptySearchTermAssert => string.Equals("Please enter a search keyword", Browser.Driver.FindElement(searchResultContent).Text);
    }
}