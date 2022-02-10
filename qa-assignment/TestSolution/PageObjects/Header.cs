// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using NUnit.Framework;
using OpenQA.Selenium;
using TestHelpers;

namespace PageObjects
{
    public class BasePage
    {
        private By searchForm = By.Id("searchbox");
        private By searchInput = By.Id("search_query_top");
        private By searchBtn = By.CssSelector("button.btn.btn-default.button-search");
        
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
    }
}