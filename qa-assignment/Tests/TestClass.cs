using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

public class TestClass
{
    public IWebDriver driver;

    [SetUp]
    public void TestSetup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        driver.Navigate().GoToUrl("http://google.com");
    }

    [Test]
    public void FirstTest()
    {
        Console.WriteLine("Test numero Uno");
    }

    [TearDown]
    public void TestTearDown()
    {
        driver.Quit();
    }
}