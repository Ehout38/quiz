# Quiz

ASP.NET Core MVC quiz for project assignment 28.

- Eight questions stored with their answers in a static collection.
- One question and four single-choice answers per page.
- Progress is stored in the server session.
- Final score and answer review, with an option to restart.
- Razor Tag Helpers for links, forms, inputs and validation.

## Run

Install the .NET 8 SDK. Open `Quiz.sln` in Visual Studio 2022 (17.8 or newer) and run the project, or run:

```sh
dotnet run --project Quiz.csproj --urls http://localhost:5101
```

Open http://localhost:5101. No database or API key is needed.
