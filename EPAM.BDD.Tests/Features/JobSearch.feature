Feature: Job Search

  As a website visitor
  I want to search for jobs
  So that I can view a relevant job

  Scenario Outline: Validate job search
    Given I am on the EPAM home page
    When I open the job search from Careers
    And I search for a "<language>" job in "<location>"
    And I open the latest job
    Then the job title should not be empty
    And the job details should contain "<language>"

    Examples:
      | language | location                |
      | Java     | All available countries |
      | Python   | All available countries |