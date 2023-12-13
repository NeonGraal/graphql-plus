﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeEnumsTests
  : TestDescriptions<EnumDeclAst>
{
  private readonly IMerge<EnumValueAst> _enumValues;
  private readonly MergeEnums _merger;

  public MergeEnumsTests()
  {
    _enumValues = Substitute.For<IMerge<EnumValueAst>>();
    _enumValues.CanMerge([]).ReturnsForAnyArgs(true);

    _merger = new(_enumValues);
  }

  protected override DescribedsMerger<EnumDeclAst> MergerDescribed => _merger;

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameExtends_ReturnsTrue(string name)
    => CanMerge_True([new EnumDeclAst(AstNulls.At, name), new EnumDeclAst(AstNulls.At, name)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentExtends_ReturnsFalse(string name, string extends)
    => CanMerge_False([new EnumDeclAst(AstNulls.At, name) { Extends = extends }, new EnumDeclAst(AstNulls.At, name)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsValuesCantMerge_ReturnsFalse(string name)
  {
    _enumValues.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([new EnumDeclAst(AstNulls.At, name), new EnumDeclAst(AstNulls.At, name)]);
  }

  protected override EnumDeclAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}
