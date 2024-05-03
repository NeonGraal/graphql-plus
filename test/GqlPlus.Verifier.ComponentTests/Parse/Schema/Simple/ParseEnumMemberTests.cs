using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

public sealed class ParseEnumMemberTests(
  Parser<EnumMemberAst>.D parser
) : TestAliased<string>
{
  internal override ICheckAliased<string> AliasChecks => _checks;

  private readonly ParseEnumMemberChecks _checks = new(parser);
}

internal sealed class ParseEnumMemberChecks
  : CheckAliased<string, EnumMemberAst>
{
  public ParseEnumMemberChecks(Parser<EnumMemberAst>.D parser)
    : base(parser) { }

  protected internal override EnumMemberAst NamedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => input + aliases;
}
