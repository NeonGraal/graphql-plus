using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging.Globals;

namespace GqlPlus.Merging.Schema.Globals;

public class MergeCategoriesTests(
  ITestOutputHelper outputHelper
) : TestAliasedAsts<IGqlpSchemaCategory>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameOutput_ReturnsGood(string category)
    => CanMerge_Good([MakeCategory(category), MakeCategory(category)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentOutput_ReturnsErrors(string name, string category1, string category2)
    => this
      .SkipIf(category1 == category2)
      .CanMerge_Errors(
        MakeCategory(category1) with { Name = name },
        MakeCategory(category2) with { Name = name });

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentOption_ReturnsErrors(string category)
    => CanMerge_Errors([
      MakeCategory(category) with { Option = CategoryOption.Single },
      MakeCategory(category) with { Option = CategoryOption.Sequential }]);

  [Theory, RepeatData]
  public void Merge_TwoAstsSameOutput_ReturnsExpected(string category)
      => Merge_Expected(
        [MakeCategory(category), MakeCategory(category)],
        MakeCategory(category));

  private readonly MergeCategories _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpSchemaCategory> MergerGroups => _merger;

  protected override IGqlpSchemaCategory MakeAliased(string name, string[]? aliases = null, string description = "")
    => new CategoryDeclAst(AstNulls.At, name, description, new TypeRefAst(AstNulls.At, name)) { Aliases = aliases ?? [] };

  private static CategoryDeclAst MakeCategory(string name)
    => new(AstNulls.At, name, "", new TypeRefAst(AstNulls.At, name));
}
