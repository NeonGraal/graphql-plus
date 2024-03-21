using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarStringTests(
  Parser<AstScalar>.D parser
) : BaseScalarTests<ScalarStringInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithRegexes_ReturnsCorrectAst(ScalarStringInput input, string regex)
    => _checks.TrueExpected(
      input.Name + "{string/" + input.Regex + "/!/" + regex + "/}",
      new AstScalar<ScalarRegexAst>(AstNulls.At, input.Name, ScalarDomain.String, new[] { input.Regex, regex }.ScalarRegexes()));

  [Theory, RepeatData(Repeats)]
  public void WithRegexesFirstBad_ReturnsFalse(string name)
    => _checks.False(name + "{string/}");

  [Theory, RepeatData(Repeats)]
  public void WithRegexesSecondBad_ReturnsFalse(ScalarStringInput input, string regex)
    => _checks.False(input.Name + "{string/" + input.Regex + "/!/" + regex + "}");

  internal override IBaseScalarChecks<ScalarStringInput> ScalarChecks => _checks;

  private readonly ParseScalarStringChecks _checks = new(parser);
}

internal sealed class ParseScalarStringChecks(
  Parser<AstScalar>.D parser
) : BaseScalarChecks<ScalarStringInput, AstScalar>(parser, ScalarDomain.String)
{
  protected internal override AstScalar<ScalarRegexAst> NamedFactory(ScalarStringInput input)
    => new(AstNulls.At, input.Name, ScalarDomain.String, new[] { input.Regex }.ScalarRegexes());

  protected internal override string AliasesString(ScalarStringInput input, string aliases)
    => input.Name + aliases + "{string/" + input.Regex + "/}";
  protected internal override string KindString(ScalarStringInput input, string kind, string parent)
    => input.Name + "{" + parent + kind + "/" + input.Regex + "/}";
}

public record struct ScalarStringInput(string Name, string Regex);
