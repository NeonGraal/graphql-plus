using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Simple;

public sealed class ParseEnumLabelTests(
  IBaseAliasedChecks<string, IGqlpEnumLabel> checks
) : BaseAliasedTests<string, IGqlpEnumLabel>(checks)
{ }

internal sealed class ParseEnumLabelChecks(
  Parser<IGqlpEnumLabel>.D parser
) : BaseAliasedChecks<string, EnumLabelAst, IGqlpEnumLabel>(parser)
{
  protected internal override EnumLabelAst NamedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => input + aliases;
}
