using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseScalarChecks
  : BaseAliasedParserChecks<ScalarInput, ScalarDeclAst>
{
  public ParseScalarChecks(Parser<ScalarDeclAst>.D parser)
    : base(parser)
  { }

  protected internal override ScalarDeclAst AliasedFactory(ScalarInput input)
    => new(AstNulls.At, input.Name) {
      Kind = ScalarKind.String,
      Regexes = input.Regex.ScalarRegexes(),
    };

  protected internal override string AliasesString(ScalarInput input, string aliases)
    => input.Name + aliases + "{string/" + input.Regex + "/!}";
}

public record struct ScalarInput(string Name, string Regex);
