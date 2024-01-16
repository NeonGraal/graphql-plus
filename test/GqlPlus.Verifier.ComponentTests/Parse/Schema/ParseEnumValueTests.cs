using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseEnumValueTests(
  Parser<EnumValueAst>.D parser
) : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id, string value)
    => _checks.False($"{id}{{{value}}}");

  internal override IBaseAliasedChecks<string> AliasChecks => _checks;

  private readonly ParseEnumValueChecks _checks = new(parser);
}

internal sealed class ParseEnumValueChecks
  : BaseAliasedChecks<string, EnumValueAst>
{
  public ParseEnumValueChecks(Parser<EnumValueAst>.D parser)
    : base(parser) { }

  protected internal override EnumValueAst AliasedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => input + aliases;
}
