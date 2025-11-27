# Architecture — TrendWatch (small project)

Purpose

This document describes a minimal, easy-to-follow architecture for small C# projects used in this repo. It focuses on a tiny, testable core, clear responsibilities, and simple wiring using the dotnet CLI.

Audience: students and contributors who will add small classes and unit tests.

Project layout (recommended)

- TrendWatch.sln — solution
- src/
  - TrendWatch.Core/  (class library: domain + pure business logic)
  - TrendWatch.Api/   (optional: Web API / app wiring / I/O adapters)
- tests/
  - TrendWatch.Core.Tests/ (xUnit tests)

Why this layout

- Keep business logic in a small, dependency-free core (`TrendWatch.Core`).
- Isolate I/O, framework and adapters in higher-level projects (e.g. `Api`).
- Tests mirror the core namespace under `tests/` so test discovery and CI are straightforward.

How to create the solution and projects (dotnet CLI)

Run these commands to bootstrap a new solution and projects locally:

```bash
dotnet new sln -n TrendWatch
mkdir -p src tests
dotnet new classlib -n TrendWatch.Core -o src/TrendWatch.Core
# optional api: dotnet new webapi -n TrendWatch.Api -o src/TrendWatch.Api
dotnet new xunit -n TrendWatch.Core.Tests -o tests/TrendWatch.Core.Tests

# add projects to solution
dotnet sln add src/TrendWatch.Core/TrendWatch.Core.csproj
# add optional API: dotnet sln add src/TrendWatch.Api/TrendWatch.Api.csproj

# make tests reference the core
dotnet add tests/TrendWatch.Core.Tests/TrendWatch.Core.Tests.csproj reference src/TrendWatch.Core/TrendWatch.Core.csproj
```

Component responsibilities

- TrendWatch.Core (domain + rules)
  - Pure business logic and small helper classes.
  - No direct I/O, no static mutable state.
- TrendWatch.Api (adapter)
  - Wiring, HTTP controllers, persistence adapters, and DI composition.
- Tests
  - Unit tests live under `tests/` alongside project names.

Where to place `Aanbiedingchecker`

`Aanbiedingchecker` contains pure business logic (date and price calculations); it belongs in `src/TrendWatch.Core/` as a small class or static helper. Keep it focused on computation and avoid DateTime.Now inside production logic — prefer injecting an `IClock` (or a `DateTime` parameter) for determinism in tests.

Example minimal placement (conceptual)

- src/TrendWatch.Core/Aanbiedingchecker.cs → class `Aanbiedingchecker`
- tests/TrendWatch.Core.Tests/AanbiedingcheckerTests.cs → class `AanbiedingcheckerTests`

Notes on determinism

- Prefer passing a clock or timestamp into public methods instead of using `DateTime.Now` directly. This makes tests deterministic and pure.
- If you need to interact with I/O or time, keep adapters at the Api or adapter layer and pass values into the core.

Quick checklist

- [ ] Create solution and projects (see CLI commands above).
- [ ] Move / add domain classes into `src/TrendWatch.Core`.
- [ ] Add unit tests under `tests/TrendWatch.Core.Tests` that mirror public APIs.
- [ ] Ensure public methods have unit tests (see coding standards).
- [ ] Run `dotnet test` and fix failing tests.

Links

- Coding standards and testing policy: ../Docs/CODING-STANDARDS.md

