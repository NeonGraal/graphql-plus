using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseScalarChecks
  : BaseAliasedChecks<ScalarInput, ScalarAst>
{
  public ParseScalarChecks()
    : base(parser => parser.ParseScalarDeclaration(""))
  { }

  protected internal override ScalarAst AliasedFactory(ScalarInput input)
    => new(AstNulls.At, input.Name) {
      Kind = ScalarKind.String,
      Regexes = input.Regex.ScalarRegexes(),
    };

  protected internal override string AliasesString(ScalarInput input, string aliases)
    => input.Name + aliases + "=string/" + input.Regex + "/!";
}

public record struct ScalarInput(string Name, string Regex);
