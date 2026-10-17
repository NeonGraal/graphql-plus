# TODO

The repository follows the staged plan in `C:\Dev\graphql-plus.github.io\plan` closely: the parser, schema modeller, verifier, encoder/decoder packages, and generator layers line up with the planned stages for the .NET library. The remaining work is therefore mostly a finishing pass rather than a large missing architecture.

A second follow-up item is a final stage-by-stage verification pass against the plan documents in `C:\Dev\graphql-plus.github.io\plan/dotnet-library`. The package layout already reflects the plan, but the project still needs a deliberate audit to confirm each stage has equivalent coverage in tests, documentation, and edge-case validation rather than just the matching class structure.

## Request implementation

- Add a unified request-envelope path that applies side-channel overrides and preserves compatibility with the legacy key/value format.
- Add pluggable raw-body deserialization, starting with JSON and leaving YAML as an optional add-on; test malformed bodies and unsupported content types.
- Define the request value and result contracts, and decide whether Request will adapt the existing `Structured`/AST types or migrate to the planned `IGqlpValue`/`Gqlp*` model.
- Implement schema-directed parameter decoding incrementally, beginning with scalar coercions and variable defaults, then adding modifiers, structured types, tags, and unions/alternates.
