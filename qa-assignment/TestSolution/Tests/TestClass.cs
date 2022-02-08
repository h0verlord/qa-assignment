using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using TestHelpers;

public class TestClass
{
    public IWebDriver driver;

    [OneTimeSetUp]
    public void Setup()
    {
        Browser.CreateDriver();
        Browser.NaigateTo();
    }

    [Test]
    public void FirstTest()
    {
        Console.WriteLine("Test numero Uno");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Browser.Driver.Close();
        Browser.Driver.Quit();
    }
}