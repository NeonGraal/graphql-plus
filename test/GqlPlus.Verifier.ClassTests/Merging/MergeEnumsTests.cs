﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeEnumsTests
  : TestDescriptions<EnumDeclAst>
{
  private readonly MergeEnums _merger = new();

  protected override DescribedMerger<EnumDeclAst> MergerDescribed => _merger;

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameExtends_ReturnsTrue(string name)
  {
    var items = new[] { new EnumDeclAst(AstNulls.At, name), new EnumDeclAst(AstNulls.At, name) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentExtends_ReturnsFalse(string name, string extends)
  {
    var items = new[] { new EnumDeclAst(AstNulls.At, name) { Extends = extends }, new EnumDeclAst(AstNulls.At, name) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  protected override EnumDeclAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
  protected override EnumDeclAst MakeDistinct(string name)
    => new(AstNulls.At, name);
}
