using EPAM.BDD.Tests.Drivers;
using EPAM.BDD.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace EPAM.BDD.Tests.StepDefinitions;

[Binding]
public class JobSearchSteps
{
    private readonly IWebDriver _driver;

    private readonly HomePage _homePage;
    private readonly CareersPage _careersPage;
    private readonly JobsPage _jobsPage;
    private readonly JobDetailsPage _jobDetailsPage;
    private readonly CookieBanner _cookieBanner;

    public JobSearchSteps(WebDriverManager webDriverManager)
    {
        _driver = webDriverManager.Driver;

        _homePage = new HomePage(_driver);
        _careersPage = new CareersPage(_driver);
        _jobsPage = new JobsPage(_driver);
        _jobDetailsPage = new JobDetailsPage(_driver);
        _cookieBanner = new CookieBanner(_driver);
    }

    [When("I open the job search from Careers")]
    public void WhenIOpenTheJobSearchFromCareers()
    {
        _homePage.OpenCareers();

        _careersPage.ClickStartYourSearchHereButton();

        _cookieBanner.AcceptCookies();
    }

    [When("I search for a {string} job in {string}")]
    public void WhenISearchForAJobIn(string language, string location)
    {
        _jobsPage.SetLocation(location);
        _jobsPage.EnterKeyword(language);
        _jobsPage.SelectRemote();
        _jobsPage.ClickSearch();
    }

    [When("I open the latest job")]
    public void WhenIOpenTheLatestJob()
    {
        _jobsPage.OpenLastJob();
    }

    [Then("the job title should not be empty")]
    public void ThenTheJobTitleShouldNotBeEmpty()
    {
        var title = _jobDetailsPage.GetJobTitle();

        Assert.That(title, Is.Not.Null.And.Not.Empty, "Job title is empty.");
    }

    [Then("the job details should contain {string}")]
    public void ThenTheJobDetailsShouldContain(string language)
    {
        Assert.That(_jobDetailsPage.IsLanguagePresent(language), Is.True, $"Language '{language}' was NOT found on job details page.");
    }
}
