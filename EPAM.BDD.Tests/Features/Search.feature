Feature: Search from home page

  As a website visitor
  I want to search from the EPAM home page
  So that I can see search results

  Scenario Outline: Validate search results using magnifier icon
    Given I am on the EPAM home page
    When I search for "<searchItem>" using the magnifier icon
    Then not all search result titles should contain "<searchItem>"

    Examples:
      | searchItem |
      | BLOCKCHAIN |
      | Cloud      |
      | Automation |