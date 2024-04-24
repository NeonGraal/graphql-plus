﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Simple;

public class MergeEnumsTests
  : TestTyped<AstType, EnumDeclAst, string, EnumMemberAst>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsValuesCantMerge_ReturnsErrors(string name, string[] values)
    => this
      .SkipUnless(values)
      .CanMergeReturnsError(_enumMembers)
    .CanMerge_Errors(
      new EnumDeclAst(AstNulls.At, name) with { Members = values.EnumMembers() },
      new EnumDeclAst(AstNulls.At, name));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsValues_ReturnsExpected(string name, string[] values1, string[] values2)
  {
    var combined = values1.EnumMembers().Concat(values2.EnumMembers()).ToArray();

    Merge_Expected([
      new EnumDeclAst(AstNulls.At, name) with { Members = values1.EnumMembers() },
      new EnumDeclAst(AstNulls.At, name) with { Members = values2.EnumMembers() }],
      new EnumDeclAst(AstNulls.At, name) with { Members = combined });
  }

  private readonly IMerge<EnumMemberAst> _enumMembers;
  private readonly MergeEnums _merger;

  public MergeEnumsTests(ITestOutputHelper outputHelper)
  {
    _enumMembers = Merger<EnumMemberAst>();

    _merger = new(outputHelper.ToLoggerFactory(), _enumMembers);
  }

  internal override AstTypeMerger<AstType, EnumDeclAst, string, EnumMemberAst> MergerTyped => _merger;

  protected override EnumDeclAst MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override string MakeParent(string parent)
    => parent;
}
