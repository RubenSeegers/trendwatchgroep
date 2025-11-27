# Coding standards — TrendWatch (small project)

Purpose

This document defines coding and testing rules for small, testable C# projects in this repo. Follow these rules to keep code simple, reviewable, and easy to test.

Core rules

- Prefer small classes and single responsibility. If a class has more than one reason to change, split it.
- Aim for small methods: prefer < 20 lines; avoid methods longer than ~50 lines without refactor.
- Prefer composition and small helpers over deep inheritance.
- Avoid static mutable state and global singletons.
- Prefer immutable DTOs and readonly fields where appropriate.

Functional purity guidance

- Express business logic as pure functions where feasible: output depends only on inputs and no hidden mutable state.
- Keep side-effects (I/O, time, randomness) at the adapter layer. Inject required values (clock, random source, configuration) into pure functions instead of reading them directly.
- Example pure helper:

```csharp
public static string CollapseWhitespace(string input) =>
    string.Join(" ", (input ?? "").Split((char[])null, StringSplitOptions.RemoveEmptyEntries));
```

Naming conventions

- Files and classes: PascalCase (e.g., `Aanbiedingchecker.cs`, class `Aanbiedingchecker`).
- Test files: Mirror the source filename and append `Tests` (e.g., `AanbiedingcheckerTests.cs`).
- Test classes: `<ClassName>Tests`.
- Test methods: `MethodUnderTest_StateUnderTest_ExpectedBehavior` (use underscores to aid readability).

Testing policy (required)

- Every public method must have unit tests in the corresponding test project.
- Use xUnit for new test projects (recommended). Open to NUnit or MSTest only if the project already uses them.
- Use `[Fact]` for single-case tests and `[Theory]` with `[InlineData]` for parameterized scenarios.
- Mock or stub external dependencies; keep tests focused on the unit under test.
- Follow AAA (Arrange / Act / Assert) structure within each test.
- Prefer one logical assertion per test; group related assertions carefully.

Test file & method naming examples

- Source: `src/TrendWatch.Core/Aanbiedingchecker.cs` (class `Aanbiedingchecker`)
- Test: `tests/TrendWatch.Core.Tests/AanbiedingcheckerTests.cs` (class `AanbiedingcheckerTests`)
- Example test method name: `IsAanbiedingGeldig_StartBeforeEnd_ReturnsTrue`

Example test skeleton (xUnit)

```csharp
using System;
using Xunit;

public class AanbiedingcheckerTests
{
    [Fact]
    public void IsAanbiedingGeldig_StartBeforeEnd_ReturnsTrue()
    {
        // Arrange
        var start = new DateTime(2020,1,1);
        var end = new DateTime(2020,12,31);
        var clock = new DateTime(2020,6,1);

        // Act
        var result = Aanbiedingchecker.IsAanbiedingGeldig(start, end); // prefer passing clock in real code

        // Assert
        Assert.True(result);
    }
}
```

Review & CI

- Ensure `dotnet test` passes locally before opening a PR.
- CI must run `dotnet test` and fail the build on test failures.
- PRs touching public APIs must include or update corresponding tests.

Quick checklist

- [ ] New public method -> add tests under `tests/`.
- [ ] Test names follow the `Method_State_Expected` convention.
- [ ] No static mutable state introduced without strong justification.
- [ ] Side-effects isolated behind adapters/interfaces.

Further recommendations

- Choose numeric thresholds (method length, class LOC) as a team; defaults: method 20 lines, class 200 LOC.
- Prefer `IClock` or passing DateTime values into logic to make tests deterministic.

Links

- Architecture guidance: ../Docs/ARCHITECTURE.md
- Global prompting & functional guidance: ../copilot-instructions.md

