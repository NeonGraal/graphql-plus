# GraphQL+ Agent Instructions

Before making changes in this repository:

1. Read `Style-Guide.md` for the repository-wide coding style.
2. Read `Conventions.md` for test-specific rules.
3. Follow the local patterns in the files you touch.
4. Avoid unrelated cleanup unless the requested change requires it.

Whilst making changes to this repository:

1. Always create a plan first.
2. Always split changes into commits of logically related files, but only commit once a build passes.
3. If a large number of Component or Container tests fail, try running `autoverify.ps1` to recreate the verification files.
