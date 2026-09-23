# TODO

The repository follows the staged plan in `C:\Dev\graphql-plus.github.io\plan` closely: the parser, schema modeller, verifier, encoder/decoder packages, and generator layers line up with the planned stages for the .NET library. The remaining work is therefore mostly a finishing pass rather than a large missing architecture.

A second follow-up item is a final stage-by-stage verification pass against the plan documents in `C:\Dev\graphql-plus.github.io\plan/dotnet-library`. The package layout already reflects the plan, but the project still needs a deliberate audit to confirm each stage has equivalent coverage in tests, documentation, and edge-case validation rather than just the matching class structure.
