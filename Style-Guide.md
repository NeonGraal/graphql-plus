# GraphQL+ Style Guide

This guide captures the coding style already used across the GraphQL+ solution. It is written for both humans and coding agents.

## How to use this guide

- Read this file before making code changes.
- Use `Conventions.md` for test-specific rules and expectations.
- Match the surrounding file when working in a legacy or generated area; do not restyle unrelated code.
- Prefer rules that are already supported by `.editorconfig` and `format.ps1`.

## Core principles

1. Optimize for clear, explicit, behavior-safe code.
2. Prefer small, surgical changes over broad cleanup.
3. Use modern C# features when they improve readability, not just because they are available.
4. Let formatters and analyzers handle structure; reserve human judgment for naming, design, and intent.

## File and namespace layout

- Use one primary type per file.
- Keep the file name aligned with the primary type name.
- Use file-scoped namespaces.
- Keep `using` directives outside the namespace.
- Let `System.*` usings come first.
- Prefer project-level global usings for imports that are shared widely inside a project.

## Naming

- Use PascalCase for public, protected, and internal types and members.
- Prefix interfaces with `I`.
- Use `_camelCase` for private instance fields.
- Use `s_camelCase` for private static fields.
- Use camelCase for locals and parameters.
- Use PascalCase for extracted local functions.
- Prefer the shortest name that is still clear in the current scope.
- Drop redundant context, type, and implementation-detail words when the surrounding type, member signature, or namespace already provides them.
- Prefer domain terms over mechanical suffixes such as `Value`, `Data`, `Info`, `Item`, `Object`, or `String` unless they add real meaning.
- Keep test method names in the `MethodUnderTest_StateUnderTest_ExpectedResult` form.

## Formatting and layout

- Indent with 2 spaces, never tabs.
- Keep lines within 150 characters when practical.
- Put opening braces on a new line for type and member declarations.
- Keep opening braces on the same line for control statements.
- Always keep braces, even for single-statement branches and loops.
- Keep `else`, `catch`, and `finally` on the same line as the preceding closing brace.
- Avoid multiple consecutive blank lines.

## Types and language features

- Prefer explicit variable types over `var`.
- Still prefer target-typed `new()` when the type is already obvious from the declaration.
- Prefer collection expressions such as `[]` when they make the code shorter without hiding the element type.
- Prefer object and collection initializers over step-by-step mutation where practical.
- Prefer primary constructors for records and service-like types when the constructor parameters are part of the type's shape.
- Prefer records and record structs for value-like data carriers; prefer classes for behavioral or stateful types.
- Prefer expression-bodied members only when the whole member remains simple and easy to scan.
- Prefer switch expressions, pattern matching, null propagation, and coalescing when they reduce noise.
- Keep generic constraints on their own lines when that improves readability.

## Nullability and control flow

- Treat nullable annotations as part of the contract.
- Prefer `is null` and `is not null` checks over reference-equality helpers.
- Reuse existing helpers such as `ThrowIfNull` when they express intent clearly.
- Prefer positive conditions when they are at least as readable as a negated alternative.
- Do not silently ignore invalid input; throw or surface an error explicitly.

## Collections and fluent code

- Prefer collection expressions for simple literals and temporary lists.
- Prefer fluent chains when each call adds one clear step.
- Break long fluent chains over multiple lines with one call per line.
- Keep nested lambdas and local functions small; extract them once they stop being obvious.

## Comments and documentation

- Prefer self-explanatory names over explanatory comments.
- Add comments only for intent, invariants, or non-obvious behavior.
- Avoid banner comments, `#region`, and placeholder TODOs without a real follow-up.
- XML documentation is optional; add it when a public API needs external-facing explanation.

## Tests

- Follow `Conventions.md` for detailed test rules.
- Use xUnit v3, AutoData or `RepeatData`, Shouldly, and NSubstitute in the established patterns.
- Keep test data explicit and readable.
- Use test parameters for primitive constants when parameterization improves coverage.
- Renderer class tests should inherit from `RendererClassTestBase` and assert structured output with `.ToLines(false)`.

## Automation boundaries

| Area                                                                                                                      | Primary enforcement                                         |
| ------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------- |
| Indentation, braces, blank lines, namespace shape, using placement                                                        | `.editorconfig` + `dotnet format whitespace`                |
| Explicit types, simple `using`, target-typed `new()`, collection expressions, switch expressions, null-handling refactors | `.editorconfig` + `dotnet format style --severity info`     |
| Analyzer-backed simplifications and code-quality fixes                                                                    | `.editorconfig` + `dotnet format analyzers --severity info` |
| Redundant type words in identifiers                                                                                       | `.editorconfig` naming analyzers (for example `CA1720`)     |
| Naming clarity, record-vs-class choice, comment necessity, positive-condition preference                                  | Human review and local file patterns                        |

## Agent checklist

Before generating or editing code:

1. Read `Style-Guide.md`.
2. Read `Conventions.md` when touching tests.
3. Inspect nearby files and follow their established patterns.
4. Keep edits focused on the requested change.
