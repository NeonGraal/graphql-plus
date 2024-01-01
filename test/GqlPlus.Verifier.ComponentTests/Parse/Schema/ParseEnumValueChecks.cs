using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

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
