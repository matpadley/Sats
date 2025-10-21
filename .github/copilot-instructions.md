<!-- Copilot instructions for the Sats repository -->
# Copilot / AI agent instructions — Sats (concise)

This repo is a small ASP.NET Core 8.0 MVC web app that generates arithmetic and fraction questions for display.
Keep suggestions focused, minimal, and consistent with the existing code style (C# 11, nullable enabled, simple controller-based MVC).

Key files to read before making changes
- `Program.cs` — standard minimal-host setup and route mapping (default route -> `HomeController`).
- `Controllers/HomeController.cs` — entry points: `Index()` (arithmetic), `Fractions()` (fractions), `Privacy()`, `Error()`.
- `Models/ArithmaticBase.cs`, `Models/ArithmeticQuestion.cs`, `Models/FractionsQuestion.cs` — core domain logic for question generation. Treat these as the source of truth for question properties and behavior.
- `Views/*` — Razor views render the questions. Shared component: `Views/Shared/Components/FractionDisplay/Default.cshtml` is used to render fraction pieces.
- `Sats.csproj` and `Dockerfile` — project target is .NET 8.0; dockerfile shows how the app is built and published.

Big-picture architecture and conventions
- App is an ASP.NET Core MVC site (no API controllers). UI is server-rendered Razor views. Routing uses the default pattern mapped in `Program.cs`.
- Domain: question generation lives entirely in models. Controllers create lists of questions (36 items) and pass them to views. Keep UI logic in views and domain logic in `Models`.
- Randomness: constructors in `ArithmeticQuestion` and `FractionsQuestion` create random questions. If you need deterministic behaviour for tests, refactor to inject a `Random` or a generator interface.
- Styling and icons: questions use Font Awesome class names for operators (see `ArithmeticQuestion` where Operator is set to e.g., `"fa fa-plus"`). Keep that representation when changing operator rendering.

Build / run / debug
- Local build and run (requires .NET 8 SDK):
```bash
dotnet restore
dotnet build
dotnet run
```
- Docker build (matches repository Dockerfile):
```bash
docker build -t sats:local .
docker run -p 8080:8080 sats:local
```
- Visual Studio / Rider: open `Sats.sln` and run the project as an ASP.NET Core app. The project uses nullable reference types and implicit usings.

Testing and determinism
- There are no tests in the repository. When adding tests, prefer extracting randomness (pass a seeded `Random`) so tests can assert deterministic values. Look at `ArithmeticQuestion`'s use of `Random` for examples.

Patterns and project-specific rules
- Files use nullable reference types (see `<Nullable>enable</Nullable>` in `Sats.csproj`). Follow that in new code.
- Minimal host pattern in `Program.cs`. Add services via `builder.Services` if you need DI (e.g., register a `IRandomGenerator` for testability).
- Views components: Fraction display is a view component under `Views/Shared/Components/FractionDisplay/Default.cshtml` (model is `FractionsQuestion`). Keep component model shape in sync with `Models/FractionsQuestion`.

When you edit code
- Small, focused changes only. Preserve the existing style: XML/inline docs in controllers, expression-bodied members where appropriate, and concise constructors in model classes.
- If changing question generation logic, update the corresponding view(s) and any Font Awesome operator strings (search for `fa fa-` in `Models/ArithmeticQuestion.cs`).
- When introducing dependency injection for testability, register the interface in `Program.cs` and prefer constructor injection in controllers and components.

Examples to reference
- To generate questions: see `HomeController.Index()` and `.Fractions()` — both create List<T> of 36 items using the model constructors.
- Operator icon mapping: `ArithmeticQuestion` maps `+` to `"fa fa-plus"`, `-` to `"fa fa-minus"`, `x` to `"fa fa-times"`, `/` to `"fa fa-divide"`.

What NOT to change without confirmation
- The minimal host bootstrap (`Program.cs`) and default routing pattern — small projects rely on this default.
- Public model property names (e.g., `Operand1`, `AnswerNumerator`) — views depend on these names.

If something is unclear
- Ask for the desired change context: UI tweak, logic update, or testability refactor. For refactors that affect serialization or public API (views), provide a migration plan.

Short checklist for PRs
1. Keep PRs small and focused (single feature or fix).
2. Run `dotnet build` and ensure no warnings related to nullable changes.
3. If you change randomness, add a small test or explain how to reproduce results.

If you'd like, I can (on request): add seeded-random test helpers, wire a simple DI abstraction for random generation, or add a small test project.
