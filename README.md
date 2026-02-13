# CodewaveStudio

A small .NET solution that demonstrates a core library and an ASP.NET Core Razor Pages web front-end, plus a test project.

Projects
- CodewaveStudio.Core - .NET library containing domain models (Studio, Wave).
- CodewaveStudio.Web  - ASP.NET Core Razor Pages app that references the Core library.
- CodewaveStudio.Test - xUnit test project for the Core library.

Requirements
- .NET SDK 9.0

Quick start
1. Restore & build:

   dotnet build CodewaveStudio.sln

2. Run the web app (from repo root):

   dotnet run --project CodewaveStudio.Web

   The web app uses Razor Pages and serves static assets. Program.cs configures routing and maps Razor Pages.

3. Run tests:

   dotnet test

Core API (overview)

- CodewaveStudio.Core.Studio
  - Constructor: Studio(string name, IEnumerable<Wave>? waves = null)
  - Properties: Guid Id, string Name, List<Wave> Waves
  - Validates non-empty name and non-null wave entries.

- CodewaveStudio.Core.Wave
  - Constructor: Wave(string name, string description)
  - Properties: Guid Id, string Name, string Description
  - Validates non-empty name and description.

Example

```csharp
using CodewaveStudio.Core;

var wave = new Wave("First Wave", "A short description");
var studio = new Studio("My Studio", new []{ wave });
Console.WriteLine($"Studio {studio.Name} has {studio.Waves.Count} wave(s)");
```

Notes
- Target framework for all projects is net9.0 (see *.csproj files).
- The solution is small and intended as a starting point for further development.

Contributing
- Feel free to open issues or PRs. Keep changes minimal and add tests for new behavior.

License
- Add a LICENSE file or update this README with the project's license.
