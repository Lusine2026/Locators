using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EPAM.BDD.Tests.Pages;

public class JobsPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait; 
    private readonly By _locationDropdown = By.XPath("//div[@data-testid='country-dropdown']//input"); 
    private readonly By _searchButton = By.CssSelector("button[name='submit_search_box_button']");
    private readonly By _preloader = By.CssSelector("[class*='Preloader_fullSize']");
    private readonly By _jobResults = By.XPath("//a[@data-testid='job-card-link']");
    private readonly By _remoteCheckboxLabel = By.XPath("//label[contains(.,'Remote')]");
    private readonly By _searchByKeyword = By.XPath("//input[@aria-label='search']");  
    private readonly By _jobCards = By.XPath("//div[@data-testid='accordion-section-container']//a[@data-testid='job-card-link']");
    private readonly By _clearLocationButton = By.XPath("//div[@aria-hidden='true' and contains(@class,'Dropdown_clearIcon')]");
    private readonly By _allCountriesValue = By.XPath("//div[@data-testid='dropdown-value' and normalize-space()='All available countries']");
    
    public JobsPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    public void EnterKeyword(string keyword)
    {
        _wait.Until(driver =>
        {
            try
            {
                var input = driver.FindElements(_searchByKeyword)
                    .FirstOrDefault(e => e.Displayed && e.Enabled);

                if (input == null)
                    return false;

                input.Click();
                input.Clear();
                input.SendKeys(keyword);

                return input.GetAttribute("value").Equals(keyword, StringComparison.OrdinalIgnoreCase);
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        });
    }

    public void SetLocation(string location)
    {
        if (location.Equals(
            "All available countries",
            StringComparison.OrdinalIgnoreCase))
        {
            EnsureAllCountriesSelected();
            return;
        }

        ClearSelectedLocation();

        var input = _wait.Until(driver =>
        {
            try
            {
                return driver.FindElements(_locationDropdown)
                    .FirstOrDefault(e => e.Displayed && e.Enabled);
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        });

        input!.Click();
        input.SendKeys(location);

        var optionLocator = By.XPath(
            $"//div[@data-testid='dropdown-option']" +
            $"[.//span[normalize-space()='{location}']]");

        _wait.Until(driver =>
        {
            try
            {
                var option = driver.FindElements(optionLocator)
                    .FirstOrDefault(e => e.Displayed && e.Enabled);

                if (option == null)
                    return false;

                option.Click();
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        });

        WaitForPreloaderToDisappear();
    }

    public void SelectRemote()
    {
        _wait.Until(driver =>
        {
            try
            {
                var remote = driver.FindElements(_remoteCheckboxLabel)
                    .FirstOrDefault();

                if (remote == null || !remote.Displayed || !remote.Enabled)
                {
                    return false;
                }

                remote.Click();
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        });
    }

    public void ClickSearch()
    {
        WaitForPreloaderToDisappear();

        _wait.Until(driver =>
        {
            try
            {
                var button = driver.FindElements(_searchButton)
                    .FirstOrDefault(e => e.Displayed && e.Enabled);

                if (button == null)
                    return false;

                button.Click();
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        });

        WaitForJobResults();
    }

    public void OpenLastJob()
    {
        var lastJob = _wait.Until(driver =>
        {
            try
            {
                return driver.FindElements(_jobCards)
                    .Where(e => e.Displayed && e.Enabled)
                    .LastOrDefault();
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        });

        if (lastJob == null)
            throw new InvalidOperationException("No job cards found.");

        lastJob.Click();

        _wait.Until(driver =>
            driver.Url.Contains("vacancy", StringComparison.OrdinalIgnoreCase));
    }

    private void WaitForJobResults()
    {
        _wait.Until(driver =>
        {
            try
            {
                var results = driver.FindElements(_jobResults);

                return results.Count > 0 &&
                       results.Any(e => e.Displayed);
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        });

        WaitForPreloaderToDisappear();
    }

    private void WaitForPreloaderToDisappear()
    {
        _wait.Until(driver => driver.FindElements(_preloader).All(element => !element.Displayed));
    }

    private void ClearSelectedLocation()
    {
        try
        {
            var clearButton = _wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElements(_clearLocationButton)
                        .FirstOrDefault();

                    return element != null && element.Displayed && element.Enabled
                        ? element
                        : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });

            clearButton?.Click();
        }
        catch (WebDriverTimeoutException)
        {
            // No selected location, so nothing needs to be cleared.
        }
    }

    private void EnsureAllCountriesSelected()
    {
        // If already selected, do nothing.
        if (_driver.FindElements(_allCountriesValue)
            .Any(e => e.Displayed))
        {
            return;
        }

        var clearButton = _wait.Until(driver =>
        {
            try
            {
                return driver.FindElements(_clearLocationButton)
                    .FirstOrDefault(e => e.Displayed && e.Enabled);
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        });

        if (clearButton == null)
        {
            throw new InvalidOperationException(
                "Clear location button was not found.");
        }

        clearButton.Click();

        // This is important: don't continue until the UI actually changed.
        _wait.Until(driver =>
            driver.FindElements(_allCountriesValue)
                .Any(e => e.Displayed));
    }
}
