using EPAM.BDD.Tests.Drivers;
using EPAM.BDD.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace EPAM.BDD.Tests.StepDefinitions;

[Binding]
public class ServicesNavigationSteps
{
    private readonly IWebDriver _driver;
    private readonly HomePage _homePage;
    private readonly ServicesPage _servicesPage;
    private readonly CookieBanner _cookieBanner;
    private string _selectedCategory = string.Empty;

    public ServicesNavigationSteps(WebDriverManager webDriverManager)
    {
        _driver = webDriverManager.Driver;

        _homePage = new HomePage(_driver);
        _servicesPage = new ServicesPage(_driver);
        _cookieBanner = new CookieBanner(_driver);
    }

    [Given("I am on the EPAM home page")]
    public void GivenIAmOnTheEPAMHomePage()
    {
        _homePage.Open();
        _cookieBanner.AcceptCookies();
    }

    [When("I open the Services menu")]
    public void WhenIOpenTheServicesMenu()
    {
        _homePage.OpenServicesMenu();
    }

    [When("I select the {string} service category")]
    public void WhenISelectTheServiceCategory(string category)
    {
        _selectedCategory = category;

        _servicesPage.SelectServiceCategory(category);
        _cookieBanner.AcceptCookies();
    }

    [Then("I should see the correct page title")]
    public void ThenIShouldSeeTheCorrectPageTitle()
    {
        Assert.That(_selectedCategory, Is.Not.Empty);

        Assert.That(_servicesPage.HasCorrectPageTitle(_selectedCategory),Is.True,
            $"Expected page title '{_selectedCategory}' but actual title was '{_driver.Title}'.");
    }

    [Then("I should see the {string} section")]
    public void ThenIShouldSeeTheSection(string sectionName)
    {
        Assert.That(_servicesPage.IsRelatedExpertiseDisplayed(), Is.True, $"The '{sectionName}' section was not displayed.");
    }
}