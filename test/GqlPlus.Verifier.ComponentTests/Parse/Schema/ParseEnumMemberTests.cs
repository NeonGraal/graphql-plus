using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseEnumMemberTests(
  Parser<EnumMemberAst>.D parser
) : BaseAliasedTests<string>
{
  internal override IBaseAliasedChecks<string> AliasChecks => _checks;

  private readonly ParseEnumMemberChecks _checks = new(parser);
}

internal sealed class ParseEnumMemberChecks
  : BaseAliasedChecks<string, EnumMemberAst>
{
  public ParseEnumMemberChecks(Parser<EnumMemberAst>.D parser)
    : base(parser) { }

  protected internal override EnumMemberAst AliasedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => input + aliases;
}
