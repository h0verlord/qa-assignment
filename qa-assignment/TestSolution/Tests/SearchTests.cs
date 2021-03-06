using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using TestHelpers;
using PageObjects;

public class SearchTest
{
    [OneTimeSetUp]
    public void Setup()
    {
        Browser.CreateDriver();
        Generators.CreateGenerators();
        Browser.NavigateTo();
    }

    /// <summary>
    /// Opens HomePage, Asserts that SearchBar and button are present and visible.
    /// </summary>
    [Test]
    public void TestSearchTerm()
    {
        var homePage = new BasePage();
        var searchResult = homePage.SearchTerm("Test 123");
        Assert.IsTrue(searchResult.SearchTermAssert, "Search Term not found in Search results Page.");
    }

    /// <summary>
    /// Presses Enter on Empty Search Bar and asserts no keywords are searched.
    /// </summary>
    [Test]
    public void TestEmptySearchTerm()
    {
        var homePage = new BasePage();
        var searchResult = homePage.SearchTerm("");
        Assert.IsTrue(searchResult.EmptySearchTermAssert, "Expected Message 'Please enter a search keyword' not found.");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Browser.Driver.Close();
        Browser.Driver.Quit();
    }
}