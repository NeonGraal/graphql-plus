using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseOptionChecks
  : BaseAliasedChecks<string, OptionDeclAst>
{
  public ParseOptionChecks(Parser<OptionDeclAst>.D parser)
    : base(parser) { }

  internal static readonly string[] Settings = ["setting"];

  protected internal override OptionDeclAst AliasedFactory(string input)
    => new(AstNulls.At, input) { Settings = Settings.OptionSettings() };

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{setting='setting'}";
}
