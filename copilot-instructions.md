# GitHub Copilot Instructions (Global Context)

## Project Philosophy (Constraint X)
All business logic should be expressed in a purely functional style:
- Prefer classes
- No hidden mutable state; avoid static caches
- Deterministic outputs: function result depends only on inputs
- Explicit dependency injection via parameters

## Style & Patterns
- Use descriptive, intention-revealing function names
- Keep functions < 25 lines when feasible
- Favor composition over inheritance / service classes
- Avoid singletons and service locators

## Testing Guidance
- Write tests before introducing new logic
- Prioritize edge cases and property-based thinking

## Prompting Guidance
Use these patterns when requesting code:
1. Role: "You are refactoring toward a functional core."
2. Constraints: List relevant functional purity points.
3. Examples: Show a small pure helper as a model.
4. Request: Ask for minimal diff, plus rationale.

### Example Pure Helper
```csharp
public static string CollapseWhitespace(string input) =>
    string.Join(" ", (input ?? "").Split((char[])null, StringSplitOptions.RemoveEmptyEntries));
```

## Anti-Patterns (Avoid Generating)
- Static mutable caches
- Runtime type inspection for branching where simple pattern matching suffices
- Deep class hierarchies for simple transformations
- Unnecessary abstraction layers (e.g., Repository + Service + Manager for trivial logic)

## When Conflict Exists
If another artifact suggests an OO layered design, prioritize functional purity unless explicitly instructed to reconcile.

## Improvement Prompts
- "Rewrite this class as a set of pure functions returning new values."
- "Identify hidden state and propose a functional alternative."
- "Suggest a refactor eliminating side effects while keeping performance."

---
These instructions intentionally conflict with Lab 06 artifacts to teach reconciliation strategies.
