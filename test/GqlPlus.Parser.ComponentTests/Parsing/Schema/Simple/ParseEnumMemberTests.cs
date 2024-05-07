using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseEnumMemberTests(
  Parser<IGqlpEnumItem>.D parser
) : BaseAliasedTests<string>
{
  internal override IBaseAliasedChecks<string> AliasChecks => _checks;

  private readonly ParseEnumMemberChecks _checks = new(parser);
}

internal sealed class ParseEnumMemberChecks(
  Parser<IGqlpEnumItem>.D parser
) : BaseAliasedChecks<string, EnumMemberAst, IGqlpEnumItem>(parser)
{
  protected internal override EnumMemberAst NamedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => input + aliases;
}
