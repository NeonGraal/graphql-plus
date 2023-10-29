using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseScalarTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name, string regex)
    => Test.TrueExpected(
      name + "=string/" + regex + "/!",
      new ScalarAst(AstNulls.At, name) {
        Kind = ScalarKind.String,
        Regexes = regex.ScalarRegexes(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string[] aliases, string regex)
    => Test.TrueExpected(
      name + aliases.Bracket("[", "]=string/").Joined() + regex + "/!",
      new ScalarAst(AstNulls.At, name) {
        Aliases = aliases,
        Kind = ScalarKind.String,
        Regexes = regex.ScalarRegexes(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithRegexes_ReturnsCorrectAst(string name, string regex1, string regex2)
    => Test.TrueExpected(
      name + "=string/" + regex1 + "/!/" + regex2 + "/",
      new ScalarAst(AstNulls.At, name) {
        Kind = ScalarKind.String,
        Regexes = regex1.ScalarRegexes(regex2),
      });

  private static OneChecks<SchemaParser, ScalarAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out ScalarAst result) => parser.ParseScalar(out result, ""));
}
