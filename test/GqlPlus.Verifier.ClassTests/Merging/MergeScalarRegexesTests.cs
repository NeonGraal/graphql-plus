﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRegexesTests
  : TestGroups<ScalarRegexAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameExcludes_ReturnsTrue(string name)
    => CanMerge_True([
      new ScalarRegexAst(AstNulls.At, false, name),
      new ScalarRegexAst(AstNulls.At, false, name)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsFalse(string name)
    => CanMerge_False([
      new ScalarRegexAst(AstNulls.At, true, name),
      new ScalarRegexAst(AstNulls.At, false, name)]);

  private readonly MergeScalarRegexes _merger = new();

  internal override GroupsMerger<ScalarRegexAst> MergerGroups => _merger;

  protected override ScalarRegexAst MakeDistinct(string name)
    => new(AstNulls.At, false, name);
}
