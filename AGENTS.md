# GraphQL+ Agent Instructions

Use the repository docs as the source of truth:

1. Read `README.md` for the project overview, stack, and build or validation commands.
2. Read `Style-Guide.md` for repository-wide coding style.
3. Read `Conventions.md` when touching tests.

While working in this repository:

1. Follow the local patterns in the files you touch.
2. Avoid unrelated cleanup unless the requested change requires it.
3. Always create a plan first.
4. Keep changes focused and logically grouped.
5. Always split changes into commits of logically related files, but only commit once a build passes.
6. If a large number of Component or Container tests fail, try running `autoverify.ps1` to recreate the verification files.
