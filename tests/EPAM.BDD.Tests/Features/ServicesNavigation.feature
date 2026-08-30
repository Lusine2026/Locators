Feature: Services Navigation

  As a website visitor
  I want to navigate to a specific service category
  So that I can verify the correct service page is displayed

  Scenario Outline: Navigate to a service category
    Given I am on the EPAM home page
    When I open the Services menu
    And I select the "<serviceCategory>" service category
    Then I should see the correct page title
    And I should see the "Our Related Expertise" section

    Examples:
      | serviceCategory |
      | Generative AI   |
      | Responsible AI  |
