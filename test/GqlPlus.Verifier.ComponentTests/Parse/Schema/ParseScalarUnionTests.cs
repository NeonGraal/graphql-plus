using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarUnionTests(Parser<ScalarDeclAst>.D parser)
    : BaseAliasedTests<ScalarUnionInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithReferences_ReturnsCorrectAst(ScalarUnionInput input, string reference)
    => _checks.TrueExpected(
      input.Name + "{union|" + input.Reference + "|" + reference + "}",
      new ScalarDeclAst(AstNulls.At, input.Name) {
        Kind = ScalarKind.Union,
        References = input.Reference.ScalarReferences(reference),
      });

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

internal sealed class ParseScalarUnionChecks
  : BaseAliasedChecks<ScalarUnionInput, ScalarDeclAst>
{
  public ParseScalarUnionChecks(Parser<ScalarDeclAst>.D parser)
    : base(parser)
  { }

  protected internal override ScalarDeclAst AliasedFactory(ScalarUnionInput input)
    => new(AstNulls.At, input.Name) {
      Kind = ScalarKind.Union,
      References = input.Reference.ScalarReferences(),
    };

  protected internal override string AliasesString(ScalarUnionInput input, string aliases)
    => input.Name + aliases + "{union|" + input.Reference + "}";
}

public record struct ScalarUnionInput(string Name, string Reference);
