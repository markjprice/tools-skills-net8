**Command-Lines**

To make it easier to enter commands at the prompt, this page lists all commands as a single line that can be copied and pasted.

- [Chapter 1 - Hello, C#! Welcome, .NET!](#chapter-1---hello-c-welcome-net)
  - [Page 13 - Managing Visual Studio Code extensions at the command prompt](#page-13---managing-visual-studio-code-extensions-at-the-command-prompt)
  - [Page 27 - Creating a class library for entity models using SQL Server](#page-27---creating-a-class-library-for-entity-models-using-sql-server)
- [Chapter 2 - Making the Most of Your Code Editor](#chapter-2---making-the-most-of-your-code-editor)
  - [Page 67 - Code snippets](#page-67---code-snippets)
  - [Page 83 - Creating a project for a template](#page-83---creating-a-project-for-a-template)
- [Chapter 3 - Source Code Management Using Git](#chapter-3---source-code-management-using-git)
  - [Page 97 - Downloading the latest Git](#page-97---downloading-the-latest-git)
  - [Page 98 - Configuring your Git identity](#page-98---configuring-your-git-identity)
  - [Page 99 - Configuring SSH signature enforcement](#page-99---configuring-ssh-signature-enforcement)
  - [Page 101 - Configuring your default branch](#page-101---configuring-your-default-branch)
  - [Page 101 - Getting help for Git](#page-101---getting-help-for-git)
  - [Page 102 - Starting with a Git repository](#page-102---starting-with-a-git-repository)
  - [Page 103 - Creating and adding files to a Git repository in theory](#page-103---creating-and-adding-files-to-a-git-repository-in-theory)
  - [Page 104 - Creating a Git repository in practice](#page-104---creating-a-git-repository-in-practice)
  - [Page 105 - Creating a new project](#page-105---creating-a-new-project)
  - [Page 110 - Committing files](#page-110---committing-files)
  - [Page 112 - Undoing a commit](#page-112---undoing-a-commit)
  - [Page 113 - Cleaning a commit](#page-113---cleaning-a-commit)
  - [Page 115 - Ignoring files](#page-115---ignoring-files)
  - [Page 118 - Viewing differences in files](#page-118---viewing-differences-in-files)
  - [Page 124 - Filtering log output](#page-124---filtering-log-output)
  - [Page 125 - Managing remote repositories](#page-125---managing-remote-repositories)
  - [Page 130 - Walking through a branching and merging example](#page-130---walking-through-a-branching-and-merging-example)
  - [Page 134 - Deleting and listing branches](#page-134---deleting-and-listing-branches)
- [Chapter 5 - Logging, Tracing, and Metrics for Observability](#chapter-5---logging-tracing-and-metrics-for-observability)
  - [Page 193 - Viewing metrics](#page-193---viewing-metrics)
- [Chapter 6 - Documenting Your Code, APIs, and Services](#chapter-6---documenting-your-code-apis-and-services)
  - [Page 219 - Generating documentation using DocFX](#page-219---generating-documentation-using-docfx)
  - [Page 222 - Creating a DocFX project](#page-222---creating-a-docfx-project)
  - [Page 240 - Rendering Mermaid diagrams](#page-240---rendering-mermaid-diagrams)
  - [Page 243 - Converting Mermaid to SVG](#page-243---converting-mermaid-to-svg)
- [Chapter 9 - Building an LLM-Based Chat Service](#chapter-9---building-an-llm-based-chat-service)
  - [Page 339 - Ollama models](#page-339---ollama-models)
  - [Page 340 - Ollama CLI](#page-340---ollama-cli)
- [Chapter 11 - Unit Testing and Mocking](#chapter-11---unit-testing-and-mocking)
  - [Page 388 - Creating a SUT](#page-388---creating-a-sut)
- [Chapter 12 - Integration and Security Testing](#chapter-12---integration-and-security-testing)
  - [Page 429 - Developer instances of the database and migrations](#page-429---developer-instances-of-the-database-and-migrations)
  - [Page 433 - Installing the dev tunnel CLI](#page-433---installing-the-dev-tunnel-cli)
  - [Page 433 - Exploring a dev tunnel with the CLI and an echo service](#page-433---exploring-a-dev-tunnel-with-the-cli-and-an-echo-service)
- [Chapter 13 - Benchmarking Performance, Load, and Stress Testing](#chapter-13---benchmarking-performance-load-and-stress-testing)
  - [Page 468 - Using Bombardier](#page-468---using-bombardier)
  - [Page 470 - Comparing an AOT and a non-AOT web service](#page-470---comparing-an-aot-and-a-non-aot-web-service)
- [Chapter 14 - Functional and End-to-End Testing of Websites and Services](#chapter-14---functional-and-end-to-end-testing-of-websites-and-services)
  - [Page 488 - Testing web user interfaces using Playwright](#page-488---testing-web-user-interfaces-using-playwright)
  - [Page 506 - Generating tests with the Playwright Inspector](#page-506---generating-tests-with-the-playwright-inspector)
- [Chapter 15 - Containerization Using Docker](#chapter-15---containerization-using-docker)
  - [Page 527 - Configuring ports and running a container](#page-527---configuring-ports-and-running-a-container)


# Chapter 1 - Hello, C#! Welcome, .NET!

## Page 13 - Managing Visual Studio Code extensions at the command prompt

```
code --install-extension ms-dotnettools.csdevkit
```

## Page 27 - Creating a class library for entity models using SQL Server

Install EF Core tools:
```
dotnet tool install --global dotnet-ef
```

Update EF Core tools:
```
dotnet tool update --global dotnet-ef
```

Generate entity class models for all tables:
```
dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --namespace Northwind.EntityModels --data-annotations
```

# Chapter 2 - Making the Most of Your Code Editor

## Page 67 - Code snippets

Add a new **Console App** / `console` project named `SnippetDemos4Code` to the `Chapter02` solution
```
dotnet new console -o SnippetDemos4Code
dotnet sln add SnippetDemos4Code
```

Build and publish the self-contained release version of the console application for Windows, macOS and Linux:
```
dotnet publish -c Release -r win-x64 --self-contained
dotnet publish -c Release -r osx-x64 --self-contained
dotnet publish -c Release -r linux-x64 --self-contained
```

## Page 83 - Creating a project for a template

Install the project template for creating project templates:
```
dotnet new install Microsoft.TemplateEngine.Authoring.Templates
```

Package the project:
```
dotnet pack
```

Install the NuGet package:
```
dotnet new install .\bin\Release\ConsolePlusTemplate.1.0.0.nupkg
```

# Chapter 3 - Source Code Management Using Git

## Page 97 - Downloading the latest Git

Confirm the current version of Git:
```
git --version
```

## Page 98 - Configuring your Git identity

Set your name globally:
```
git config --global user.name "<your_full_name>"
git config --global user.email <your_email>
```

Set your name in a specific repository:
```
git config user.name "<your_full_name>"
git config user.email <your_email>
```

## Page 99 - Configuring SSH signature enforcement

Generate an SSH key pair:
```
ssh-keygen -t ed25519 -C "your_email@example.com"
```

Configure Git to use your SSH key for signing commits:
```
git config --global user.signingkey <your-ssh-public-key-id>
git config --global commit.gpgformat ssh
```

Sign commits using the `-S` switch:
```
git commit -S -m "your commit message"
```

Verify the signatures:
```
git log --show-signature
```

## Page 101 - Configuring your default branch

Check your default configuration:
```
git config --list --show-origin
```

Change the default branch to something less culturally insensitive, like `main`:
```
git config --global init.defaultBranch main
```

## Page 101 - Getting help for Git

```
git help <command>
git <command> --help
git <command> -h
```

## Page 102 - Starting with a Git repository

To clone an existing repository into the current directory:
```
git clone <url_to_repo>
```

To initialize a repository in the current local non-Git directory:
```
git init
```

## Page 103 - Creating and adding files to a Git repository in theory

To add all C# files (files with the extension `.cs`) and add a file named `readme.md`:
```
git add *.cs
git add readme.md
```

After adding files, you must commit them to the local repository, preferably with a message specified using the -m switch:
```
git commit -m 'Initial version'
```

## Page 104 - Creating a Git repository in practice

Get the current Git status of the current directory:
```
git status
```

## Page 105 - Creating a new project

Create a new console app in a subfolder named `RepoDemo`:
```
dotnet new console -o RepoDemo
```

Create a solution and add the `RepoDemo` project to it:
```
dotnet new sln
dotnet sln add RepoDemo
```

Stage the RepoDemo folder and all its files:
```
git add RepoDemo
```

Unstage all the files recursively (using the `-r` switch):
```
git rm --cached RepoDemo -r
```

Stage just the two important source code files in the `RepoDemo` folder and the solution file:
```
git add RepoDemo/Program.cs
git add RepoDemo/RepoDemo.csproj
git add Chapter03.sln
```

Get the current Git status of the current directory using the short switch, `-s`:
```
git status -s
```

## Page 110 - Committing files

Commit the two files with a message:
```
git commit -m "Initial version"
```

## Page 112 - Undoing a commit

Soft Reset: 
```
git reset --soft HEAD
```

Mixed Reset: 
```
git reset HEAD
```

Hard Reset: 
```
git reset --hard HEAD
```

Revert Commit:
```
git revert <commit_hash>
```

Amend Commit:
```
git commit --amend
```

## Page 113 - Cleaning a commit

Remove files that should not be tracked by Git:
```
git clean
```

Remove files and directories that should not be tracked by Git:
```
git clean -d
```

Dry run option:
```
git clean -n
```

## Page 115 - Ignoring files

Create a `.gitignore` file using the .NET SDK CLI:
```
dotnet new gitignore
```

Add and then commit the Git ignore file:
```
git add .gitignore
git commit -m "Add Git ignore file.
```

## Page 118 - Viewing differences in files

Show Git differences:
```
git diff
```

Show what differences are currently staged:
```
git diff --staged
```

Show the commit history:
```
git log
```

Show the commit history with the most recent three patches:
```
git log -p -3
```

Show the commit history statistics:
```
git log --stat
```

Show the commit history with one-line formatting:
```
git log --pretty=oneline
```

Show the commit history with a custom format that shows the full commit hash (%H), the author’s name (%an) in blue (%Cblue, %Creset), the author timestamp in ISO 8601 format (%ai), and then on a new line (%n), the commit message (%s):
```
git log --pretty=format:"Author of %H was %Cblue%an%Creset, at %ai%nMessage: %s%n"
```

Show the commit history with a custom format that shows the short commit hash (%h) and the commit message (%s), but with graphs for any branches:
```
git log --pretty=format:"%h %s" --graph
```

## Page 124 - Filtering log output

Get the commits in the last two weeks:
```
git log --since=2.weeks
git log --after=2.weeks
```

Get the commits starting in 2024:
```
git log --since=2024-01-01
git log --after=2024-01-01
```

Get the commits before 2024:
```
git log --until=2024-01-01
git log --before=2024-01-01
```

Filter by author, committer, or file path:
```
git log --author "Mark J Price"
git log --committer "Mark J Price"
git log -- RepoDemo/RepoDemo.csproj
```

Get the commits that contain the text string `ignore`:
```
git log -S "ignore"
```

## Page 125 - Managing remote repositories

List your configured remote repositories:
```
git remote -v
```

To get more information:
```
git remote show origin
```

Add your remote repository with its URL:
```
git remote add origin https://github.com/markjprice/repodemo.git
```

Push the main branch of your project up to the remote repositories:
```
git push origin main
```

## Page 130 - Walking through a branching and merging example

Stage the modified file and then commit the changes to both files with a comment message:
```
git commit -a -m "Add calculator functionality and call the Add method."
```

Create a new feature branch named `configure-console`:
```
git branch configure-console
```

Switch to the new branch:
```
git switch configure-console
```

Create (`-c`) a new feature branch and switch to it:
```
git switch -c <branch-name>
```

Create a new feature branch and switch to it (old way):
```
git checkout -b <branch-name>
```

Swtich (back) to `main` branch:
```
git switch main
```

Merge the hotfix into the main branch:
```
git merge calc-hotfix
```

## Page 134 - Deleting and listing branches

Delete the hotfix branch:
```
git branch -d calc-hotfix
```

List branches:
```
git branch
```

# Chapter 5 - Logging, Tracing, and Metrics for Observability

## Page 193 - Viewing metrics

Install the .NET Counters tool globally:
```
dotnet tool update -g dotnet-counters
```

Start monitoring the web service by specifying its PID:
```
dotnet-counters monitor -p 9552 --counters Northwind.WebApi.Metrics
```

# Chapter 6 - Documenting Your Code, APIs, and Services

## Page 219 - Generating documentation using DocFX

Install DocFX:
```
dotnet tool install -g docfx
```

Or update it to the latest version:
```
dotnet tool update -g docfx
```

Confirm that DocFX is installed:
```
dotnet tool list -g
```

## Page 222 - Creating a DocFX project

Initialize a DocFX project:
```
docfx init
```

Host the DocFX project in a web server:
```
docfx docfx.json --serve
```

## Page 240 - Rendering Mermaid diagrams

Install Mermaid CLI using Node Package Manager:
```
npm install -g @mermaid-js/mermaid-cli
```

## Page 243 - Converting Mermaid to SVG

```
mmdc -i mermaid-examples.md -o output.md
```

# Chapter 9 - Building an LLM-Based Chat Service

## Page 339 - Ollama models

To quickly download and run an Ollama model in interactive mode:
```
ollama run <model>
```

## Page 340 - Ollama CLI

Check its version:
```
ollama --version
```

Pull down a named model like Llama3:
```
ollama pull llama3
```

List the available local models:
```
ollama list
```

Run a named model (which would also download it if not already pulled):
```
ollama run llama3
```

# Chapter 11 - Unit Testing and Mocking

## Page 388 - Creating a SUT

Add a new xUnit Test Project [C#] / xunit project named `BusinessLogicUnitTests` to the `Chapter11` solution:
```
dotnet new xunit -o BusinessLogicUnitTests
dotnet sln add BusinessLogicUnitTests
```

Run the tests:
```
dotnet test --logger "console;verbosity=detailed"
```

# Chapter 12 - Integration and Security Testing

## Page 429 - Developer instances of the database and migrations

Create a new migration:
```
dotnet ef migrations add <MigrationName>
```

Run any outstanding migrations:
```
dotnet ef database update
```

To revert to a specified migration point:
```
dotnet ef database update <MigrationName>
```

To revert all migrations so that the database returns to its original state:
```
dotnet ef database update 0
```

## Page 433 - Installing the dev tunnel CLI

On Windows, use winget:
```
winget install Microsoft.devtunnel
```

On MacOS, use Homebrew:
```
brew install --cask devtunnel
```

On Linux, use curl:
```
curl -sL https://aka.ms/DevTunnelCliInstall | bash
```

## Page 433 - Exploring a dev tunnel with the CLI and an echo service

Log in:
```
devtunnel user login
```

Start hosting a simple service on port 8080 that just echoes any HTTP requests to it:
```
devtunnel echo http -p 8080
```

In another command prompt or terminal window, start hosting a dev tunnel for port 8080:
```
devtunnel host -p 8080
```

# Chapter 13 - Benchmarking Performance, Load, and Stress Testing

## Page 468 - Using Bombardier

To send 10,000 requests with 100 concurrent connections:
```
bombardier -c 100 -n 10000 http://yourwebservice.com/api/resource
```

Confirm that Bombardier is responding by asking for help:
```
bombardier --help
```

## Page 470 - Comparing an AOT and a non-AOT web service

Create a Web API project:
```
dotnet new webapi --no-https --no-openapi -o Northwind.WebApi
```

Create a Web API project for AOT:
```
dotnet new webapi --no-https --no-openapi -o Northwind.WebApiAot
```

Publish a project:
```
dotnet publish
```

Start the web service using port 5131:
```
.\Northwind.WebApi --urls="http://localhost:5131"
```

Start the web service using port 5132:
```
.\Northwind.WebApiAot --urls="http://localhost:5132"
```

Use Bombardier to make one million requests using 125 connections (simulated users) to the normal web service, which is listening on port 5131:
```
bombardier -c 125 -n 1000000 http://localhost:5131/weatherforecast
```

Use Bombardier to make one million requests using 125 connections (simulated users) to the AOT web service, which is listening on port 5132:
```
bombardier -c 125 -n 1000000 http://localhost:5132/weatherforecast
```

Use Bombardier to make as many requests as possible for 10 seconds using 200 connections to the normal web service and output the latency distribution:
```
bombardier -c 200 -d 10s -l http://localhost:5131/weatherforecast
```

# Chapter 14 - Functional and End-to-End Testing of Websites and Services

## Page 488 - Testing web user interfaces using Playwright

When running a test project, you can then specify the browser and channel:
```
dotnet test -- Playwright.BrowserName=chromium Playwright.LaunchOptions.Channel=msedge
```

Add a new `xunit` project named `WebUITests` to a `Chapter14` solution:
```
dotnet new sln
dotnet new xunit -o WebUITests
dotnet sln add WebUITests
```

Install browsers for Playwright to automate:
```
pwsh playwright.ps1 install
```

## Page 506 - Generating tests with the Playwright Inspector

Start the code generator:
```
pwsh bin/Debug/net8.0/playwright.ps1 codegen https://localhost:5001/
```

You can start the Playwright Inspector with emulation options like setting a view port size:
```
pwsh bin/Debug/net8/0/playwright.ps1 codegen --viewport-size=800,600 https://localhost:5001/
```

You could emulate a device:
```
pwsh bin/Debug/net8/0/playwright.ps1 codegen --device="iPhone 13" https://localhost:5001/
```

Run the Playwright PowerShell script with the `uninstall` option:
```
pwsh bin/Debug/net8.0/playwright.ps1 uninstall
```

To remove browsers of other Playwright installations as well, add the `--all` switch:
```
pwsh bin/Debug/net8.0/playwright.ps1 uninstall --all
```

# Chapter 15 - Containerization Using Docker

## Page 527 - Configuring ports and running a container

For an ASP.NET Core web application that listens on port 8080 within the container, you might want to map it to port 8000 on the host, making the application accessible at http://localhost:8000:
```
docker run -p 8000:8080 -d --name myaspnetapp mcr.microsoft.com/dotnet/aspnet:latest
```
