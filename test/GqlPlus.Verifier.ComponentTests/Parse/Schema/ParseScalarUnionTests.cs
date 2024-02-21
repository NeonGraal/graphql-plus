﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarUnionTests(
  Parser<AstScalar>.D parser
) : BaseScalarTests<ScalarUnionInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithReferences_ReturnsCorrectAst(ScalarUnionInput input, string reference)
    => _checks.TrueExpected(
      input.Name + "{union|" + input.Reference + "|" + reference + "}",
      new AstScalar<ScalarReferenceAst>(AstNulls.At, input.Name, ScalarKind.Union, new[] { input.Reference, reference }.ScalarReferences()));

  [Theory, RepeatData(Repeats)]
  public void WithReferencesBad_ReturnsFalse(string name)
    => _checks.False(name + "{union | }");

  [Theory, RepeatData(Repeats)]
  public void WithReferencesFirstBad_ReturnsFalse(ScalarUnionInput input, string reference)
    => _checks.False(input.Name + "{union " + input.Reference + "|" + reference + "}");

  [Theory, RepeatData(Repeats)]
  public void WithReferencesSecondBad_ReturnsFalse(ScalarUnionInput input, string reference)
    => _checks.False(input.Name + "{union|" + input.Reference + " " + reference + "}");

  internal override IBaseScalarChecks<ScalarUnionInput> ScalarChecks => _checks;

  private readonly ParseScalarUnionChecks _checks = new(parser);
}

internal sealed class ParseScalarUnionChecks(
  Parser<AstScalar>.D parser
) : BaseScalarChecks<ScalarUnionInput, AstScalar>(parser, ScalarKind.Union)
{
  protected internal override AstScalar<ScalarReferenceAst> AliasedFactory(ScalarUnionInput input)
    => new(AstNulls.At, input.Name, ScalarKind.Union, new[] { input.Reference }.ScalarReferences());

  protected internal override string AliasesString(ScalarUnionInput input, string aliases)
    => input.Name + aliases + "{union|" + input.Reference + "}";
  protected internal override string KindString(ScalarUnionInput input, string kind, string parent)
    => input.Name + "{" + parent + kind + "|" + input.Reference + "}";
}

public record struct ScalarUnionInput(string Name, string Reference);
