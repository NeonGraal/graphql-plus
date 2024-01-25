using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarUnionTests(Parser<AstScalar>.D parser)
    : BaseAliasedTests<ScalarUnionInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithReferences_ReturnsCorrectAst(ScalarUnionInput input, string reference)
    => _checks.TrueExpected(
      input.Name + "{union|" + input.Reference + "|" + reference + "}",
      new AstScalar<ScalarReferenceAst>(AstNulls.At, input.Name, ScalarKind.Union, input.Reference.ScalarReferences(reference)));

  [Theory, RepeatData(Repeats)]
  public void WithReferencesBad_ReturnsFalse(string name)
    => _checks.False(name + "{union | }");

  [Theory, RepeatData(Repeats)]
  public void WithReferencesFirstBad_ReturnsFalse(ScalarUnionInput input, string reference)
    => _checks.False(input.Name + "{union " + input.Reference + "|" + reference + "}");

  [Theory, RepeatData(Repeats)]
  public void WithReferencesSecondBad_ReturnsFalse(ScalarUnionInput input, string reference)
    => _checks.False(input.Name + "{union|" + input.Reference + " " + reference + "}");

  internal override IBaseAliasedChecks<ScalarUnionInput> AliasChecks => _checks;

  private readonly ParseScalarUnionChecks _checks = new(parser);
}

internal sealed class ParseScalarUnionChecks(
  Parser<AstScalar>.D parser
) : BaseAliasedChecks<ScalarUnionInput, AstScalar>(parser)
{
  protected internal override AstScalar<ScalarReferenceAst> AliasedFactory(ScalarUnionInput input)
    => new(AstNulls.At, input.Name, ScalarKind.Union, input.Reference.ScalarReferences());

  protected internal override string AliasesString(ScalarUnionInput input, string aliases)
    => input.Name + aliases + "{union|" + input.Reference + "}";
}

public record struct ScalarUnionInput(string Name, string Reference);
