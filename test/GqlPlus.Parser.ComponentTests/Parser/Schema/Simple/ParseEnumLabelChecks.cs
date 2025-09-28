using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parser.Schema.Simple;

internal sealed class ParseEnumLabelChecks(
  Parser<IGqlpEnumLabel>.D parser
) : BaseAliasedChecks<string, EnumLabelAst, IGqlpEnumLabel>(parser)
{
  protected internal override EnumLabelAst NamedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => input + aliases;
}
