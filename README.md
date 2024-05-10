# Sats

"Sats" is a web-based application designed to help users practice arithmetic and fraction questions. The application is built using .NET Core, HTML, CSS, and a bit of JavaScript. Deployment and CI/CD are handled via GitHub Actions.

## Application Features

The application provides the following features:

Arithmetic Questions: Generates a list of arithmetic questions for users to practice. You can access this feature through the HomeController.Index action.

Fraction Questions: Generates a list of fractions questions for users to practice. You can access this feature through the HomeController.Fractions action.

Timer and Scoring: Both the arithmetic and fractions practice pages include a timer and scoring feature, implemented in JavaScript. Users can start a 30-minute timer, and at the end of the allotted time, their responses will be automatically marked, and scores (correct and incorrect counts) will be displayed.

## GitHub Actions

The repository uses several GitHub Actions workflows to streamline the development process:

Build and Deploy to Azure Web App: This workflow, defined in master_ewansats.yml, triggers on every push to the master branch. It builds the .NET Core application, publishes it, and deploys it to an Azure Web App.

CodeQL Analysis: The codeql.yml workflow is set to analyze the codebase for potential security vulnerabilities. It runs on every push to the main branch and every pull request to the main branch. It also runs on a schedule (every Wednesday at 15:44 UTC).

Build and Push to GitHub Packages: The deploy.yml workflow triggers whenever a new release is created. It builds a Docker image of the application and pushes it to GitHub Packages.

Please note that these workflows might require certain secrets (like Azure credentials or Docker login details) to be set in your GitHub repository's settings.

## Contribution

Please feel free to contribute to the project. Any contributions or suggestions are welcome.

(Note: The above content is a suggestion based on the provided files and might need to be adjusted to suit the actual functionalities of the application.)
