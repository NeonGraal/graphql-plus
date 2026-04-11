using GqlPlus.Ast.Schema;

namespace GqlPlus.Parser.Schema.Simple;

public sealed class ParseEnumLabelTests(
  IBaseAliasedChecks<string, IAstEnumLabel> checks
) : BaseAliasedTests<string, IAstEnumLabel>(checks)
{ }
