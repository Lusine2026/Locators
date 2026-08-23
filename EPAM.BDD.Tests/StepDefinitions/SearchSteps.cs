using EPAM.BDD.Tests.Drivers;
using EPAM.BDD.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace EPAM.BDD.Tests.StepDefinitions;

[Binding]
public class SearchSteps
{
    private readonly IWebDriver _driver;
    private readonly HomePage _homePage;
    private readonly SearchPage _searchPage;

    public SearchSteps(WebDriverManager webDriverManager)
    {
        _driver = webDriverManager.Driver;

        _homePage = new HomePage(_driver);
        _searchPage = new SearchPage(_driver);
    }

    [When("I search for {string} using the magnifier icon")]
    public void WhenISearchForUsingTheMagnifierIcon(string searchItem)
    {
        _homePage.SearchByMagnifierIcon(searchItem);
    }

    [Then("not all search result titles should contain {string}")]
    public void ThenNotAllSearchResultTitlesShouldContain(string searchItem)
    {
        var resultTitles = _searchPage.GetResultsTitles();

        Assert.That(resultTitles.All(title => title.Contains(searchItem, StringComparison.OrdinalIgnoreCase)), Is.False, $"All search result titles contained '{searchItem}'.");
    }
}