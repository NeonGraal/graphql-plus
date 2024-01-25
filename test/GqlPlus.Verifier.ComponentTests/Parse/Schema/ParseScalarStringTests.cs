using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarStringTests(Parser<AstScalar>.D parser)
    : BaseAliasedTests<ScalarStringInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => _checks.False($"{id}{{String}}");

  [Theory, RepeatData(Repeats)]
  public void WithKindBad_ReturnsFalse(string name, string kind)
    => _checks.False(
      $"{name}{{{kind}}}",
      skipIf: Enum.TryParse<ScalarKind>(kind, out var _));

  [Theory, RepeatData(Repeats)]
  public void WithRegexes_ReturnsCorrectAst(ScalarStringInput input, string regex)
    => _checks.TrueExpected(
      input.Name + "{string/" + input.Regex + "/!/" + regex + "/}",
      new AstScalar<ScalarRegexAst>(AstNulls.At, input.Name, ScalarKind.String, input.Regex.ScalarRegexes(regex)));

  [Theory, RepeatData(Repeats)]
  public void WithRegexesFirstBad_ReturnsFalse(string name)
    => _checks.False(name + "{string/}");

  [Theory, RepeatData(Repeats)]
  public void WithRegexesSecondBad_ReturnsFalse(ScalarStringInput input, string regex)
    => _checks.False(input.Name + "{string/" + input.Regex + "/!/" + regex + "}");

  internal override IBaseAliasedChecks<ScalarStringInput> AliasChecks => _checks;

  private readonly ParseScalarStringChecks _checks = new(parser);
}

internal sealed class ParseScalarStringChecks(
  Parser<AstScalar>.D parser
) : BaseAliasedChecks<ScalarStringInput, AstScalar>(parser)
{
  protected internal override AstScalar<ScalarRegexAst> AliasedFactory(ScalarStringInput input)
    => new(AstNulls.At, input.Name, ScalarKind.String, input.Regex.ScalarRegexes());

  protected internal override string AliasesString(ScalarStringInput input, string aliases)
    => input.Name + aliases + "{string/" + input.Regex + "/!}";
}

public record struct ScalarStringInput(string Name, string Regex);
