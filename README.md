# Sats — SATs arithmetic revision web app

Sats is a small server-rendered ASP.NET Core 8 MVC web app that generates practice arithmetic and fraction questions for SATs-style revision. It renders simple exam-style pages (36 questions per page) with a built-in timer, reveal/marking helpers and minimal styling.

Key ideas:
- Questions are generated server-side in model constructors (no database required).
- Two practice pages: Arithmetic (decimal/whole/percentage) and Fractions.
- Lightweight client-side helpers: 30-minute timer, reveal answers (password protected), and simple marking.

## Contents
- `Controllers/HomeController.cs` — routes for the Index (arithmetic) and Fractions pages.
- `Models/` — question generation logic:
	- `ArithmeticQuestion.cs` — creates random whole/decimal/percentage problems and computes answers.
	- `FractionsQuestion.cs` — creates fraction ×/÷/+/- questions and simplifies answers.
	- `ArithmaticBase.cs` — shared operator lists.
- `Views/` — Razor views for UI (Index, Fractions, shared layout and a fraction display component).

## Quickstart — run locally

Prerequisites
- .NET 8 SDK (matching the project target)

Restore, build and run the app:

```bash
dotnet restore
dotnet build
dotnet run
```

By default the app uses the minimal-host pattern and maps the default route to `HomeController`. Open the site at https://localhost:5001 (or the URL shown in the console).

Pages
- / or /Home/Index — Arithmetic practice (36 questions)
- /Home/Fractions — Fractions practice (36 questions)

Notes about the implementation
- Randomness: both `ArithmeticQuestion` and `FractionsQuestion` create a new `Random` instance inside the constructor. If you want deterministic tests or repeatable decks, consider injecting a seeded `Random` (or an interface) via DI.
- Operator rendering: arithmetic operators are stored as Font Awesome class names (e.g. `"fa fa-plus"`) in `ArithmeticQuestion` — the views rely on this string for display.
- Fraction answers are reduced using a simple GCD routine in `FractionsQuestion`.

Docker

This repository includes a `Dockerfile` that publishes the app. To build and run the image locally:

```bash
docker build -t sats:local .
docker run -p 8080:80 sats:local
```

The container serves the published ASP.NET app on port 80 inside the image and is mapped to 8080 on the host in the example above.

Development tips
- Add dependency injection for randomness to make tests deterministic. Small interface example:

	- IRandomGenerator { double NextDouble(); int Next(int maxValue); }

- Consider moving question-generation logic out of the constructors if you want to reuse the classes for importing/exporting questions or unit testing more easily.

Testing and verification
- There are no unit tests in the repository. To add tests, create an xUnit or NUnit test project and extract Random dependency so you can pass a seeded generator and assert expected outputs.

Security and privacy
- The UI includes a simple password prompt (client-side) to reveal answers. This is purely a convenience — do not rely on it for security.

Files changed / created
- Updated `README.md` with usage, implementation notes and quickstart instructions.

Next steps (suggested)
- Add a small test project and make randomness injectable for deterministic tests.
- Improve UI/UX (responsive layout, keyboard navigation for answers, improve fraction rendering component).
- Add localization and configurable question counts/time limits.

If you'd like, I can:
- Extract Random into an injectable service and add a few unit tests (seeded) so question generation is deterministic during tests.
- Add a small GitHub Actions workflow to run `dotnet build` and tests on PRs.

---

If you want any section expanded (setup for Docker Compose, CI examples, or sample screenshots) tell me which part to prioritise.
