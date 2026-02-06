# StarWars WebApi Test Plan

## Changelog
- 2026-02-06 — Step 1 implemented (test SUT added) — PR: N/A — Author: GitHub Copilot
- 2026-02-06 — Draft created — PR: N/A — Author: GitHub Copilot
- 2026-02-06 — Require solution integration and build verification at every step — PR: N/A — Author: GitHub Copilot

Owner: @your-github-username

TL;DR
Add a self-contained, test-only Web API SUT under `test/` and a matching container test project `GqlPlus.StarWars.ContainerTests` that starts the SUT in-process (via `WebApplicationFactory<Program>`) and exercises endpoints over HTTP. Mirror existing ContainerTests and shared test bases (`GqlPlus.ComponentTestBase`, `GqlPlus.TestBase`) so tests are deterministic, multi-targeted, and analyzer-compliant.

**Steps**
1. ✅ Create test-only SUT
   - Add `test/GqlPlus.StarWars.Api/`.
   - Add `GqlPlus.StarWars.Api.csproj` (SDK `Microsoft.NET.Sdk.Web`). Keep test-only code under `test/` so it is not shipped.
   - Implement `Program.cs` (minimal host) and `Controllers/StarWarsController.cs` with deterministic endpoints, e.g.:
     - `GET /api/health` -> 200 OK
     - `GET /api/starwars/films` -> deterministic JSON
   - Use file-scoped namespaces and nullable reference types (repo defaults).
      - **Verification:** Added `test/GqlPlus.StarWars.Api` with `GqlPlus.StarWars.Api.csproj`, `Program.cs`, `Controllers/StarWarsController.cs`, and `Controllers/HealthController.cs`.

2. Add container test project
    - ✅ Add `test/GqlPlus.StarWars.ContainerTests/` and `GqlPlus.StarWars.ContainerTests.csproj`.
       - `<IsTestProject>true</IsTestProject>`
       - `ProjectReference` to `..\GqlPlus.StarWars.Api\GqlPlus.StarWars.Api.csproj`
       - `ProjectReference` to `..\GqlPlus.ComponentTestBase\GqlPlus.ComponentTestBase.csproj`
       - `ProjectReference` to `..\GqlPlus.TestBase\GqlPlus.TestBase.csproj`
    - **PackageReferences:** `Microsoft.AspNetCore.Mvc.Testing`, `Microsoft.AspNetCore.TestHost`, `Verify.SourceGenerators` (no explicit versions).
    - **Verification:** Project added to solution and builds.
       - `dotnet build GqlPlus.sln` completed successfully locally on 2026-02-06; multi-targeted `GqlPlus.StarWars.Api` and `GqlPlus.StarWars.ContainerTests` built for `net10.0;net9.0;net8.0`.

3. Implement test fixture
   - Add `StarWarsApiFactory : WebApplicationFactory<Program>` and a fixture exposing `HttpClient`.
   - Ensure `Program` is discoverable by `WebApplicationFactory` (typical top-level host pattern or explicit `Program` class).

4. Write tests
   - Add `StarWarsApiTests.cs`:
     - Use fixture to get `HttpClient`.
     - Send HTTP requests; assert status and JSON shape using `Shouldly` or xUnit assertions.
     - Optionally use `Verify` snapshots for response bodies.
   - Add `GlobalUsings.cs` and `xunit.runner.json` if needed (mirror `GqlPlus.ComponentTestBase`).

5. Solution integration
   - Add both new projects to `GqlPlus.sln` so repo scripts pick them up.
   - Ensure the solution builds successfully after adding projects; perform `dotnet build GqlPlus.sln` and include results in the Verification subsection for the PR.

6. Code quality & conventions
   - Rely on root `Directory.Build.props` and `test/Directory.Build.props` for languages and target frameworks.
   - Do not add explicit package versions in csproj; centralize via `Directory.Packages.props`.
   - Fix analyzer warnings (repo uses `TreatWarningsAsErrors`).

7. CI & scripts
   - Confirm `test.ps1` and other scripts pick up new tests once projects are added to the solution.

8. Documentation
   - Add `test/GqlPlus.StarWars.ContainerTests/README.md` with quick run instructions and SUT contract.
   - Add this plan file `StarWars-WebApi-Test-Plan.md` to the repo root or `test/` directory (prefer `test/`).

9. Verification & cleanup
   - Build and test locally; iterate until analyzers are clean.
   - Remove temporary debug code; keep tests deterministic.

**Verification**
- Build:
```powershell
dotnet build GqlPlus.sln
```
- Run tests (example):
```powershell
dotnet test test\GqlPlus.StarWars.ContainerTests\GqlPlus.StarWars.ContainerTests.csproj -f net10.0
```
- Confirm `HttpClient` against in-process SUT returns expected results.

**Decisions**
- SUT lives under `test/` (test-only, not part of ship output).
- Use `WebApplicationFactory<Program>` for in-process HTTP testing.
- Reuse `GqlPlus.ComponentTestBase` and `GqlPlus.TestBase` for logging/DI/test utilities.

**Files to mirror / inspect**
- ContainerTests example: [test/GqlPlus.Generators.ContainerTests/GqlPlus.Generators.ContainerTests.csproj](test/GqlPlus.Generators.ContainerTests/GqlPlus.Generators.ContainerTests.csproj#L1)
- Component test helpers: [test/GqlPlus.ComponentTestBase/ComponentTestStartup.cs](test/GqlPlus.ComponentTestBase/ComponentTestStartup.cs#L1)
- Test base: [test/GqlPlus.TestBase/GqlPlus.TestBase.csproj](test/GqlPlus.TestBase/GqlPlus.TestBase.csproj#L1)
- Test defaults: [test/Directory.Build.props](test/Directory.Build.props#L1)
- Central packages: [Directory.Packages.props](Directory.Packages.props#L1)
- Repo analyzers: [Directory.Build.props](Directory.Build.props#L1)

**Keeping this document up to date**
- This file is the single source-of-truth for StarWars test work. Update it in the same PR that changes code.
- Add a changelog entry at the top for each PR:
  - `YYYY-MM-DD — PR # — Short summary — Author`
- For each code change:
  - Mark completed steps with `✅` and remaining steps with `⏳`.
  - Add a `Verification` subsection with test results and CI links.
   - **Build verification:** For changes that add or modify projects, include a successful `dotnet build GqlPlus.sln` run (or CI link) in the `Verification` subsection to prove the solution builds at that checkpoint.
  - If implementation deviates from the plan, add rationale in `Decisions`.
- Ownership and review:
  - Keep `Owner:` accurate. Transfer via PR if responsibility moves.
  - Require the plan update before merging major changes.
- Editing rules:
  - Minor doc fixes can be committed directly to the branch.
  - Structural changes require a PR and a short reviewer checklist confirming the plan reflects reality.

**PR checklist (suggested)**
- [ ] `GqlPlus.StarWars.Api` added under `test/`
- [ ] `GqlPlus.StarWars.ContainerTests` project created and references SUT + test bases
- [ ] Tests run locally and in CI with no analyzer errors
- [ ] `StarWars-WebApi-Test-Plan.md` updated with PR entry and verification results
- [ ] README in test project added or updated
