using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseEnumLabelTests(
  IBaseAliasedChecks<string, IGqlpEnumLabel> checks
) : BaseAliasedTests<string, IGqlpEnumLabel>(checks)
{ }
