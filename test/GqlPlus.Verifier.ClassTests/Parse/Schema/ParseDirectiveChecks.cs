using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseDirectiveChecks
  : BaseAliasedParserChecks<string, DirectiveDeclAst>
{
  public ParseDirectiveChecks(Parser<DirectiveDeclAst>.D parser)
    : base(parser) { }

  protected internal override DirectiveDeclAst AliasedFactory(string input)
    => new(AstNulls.At, input) { Locations = DirectiveLocation.Operation };

  protected internal override string AliasesString(string input, string aliases)
    => "@" + input + aliases + "{operation}";
}
