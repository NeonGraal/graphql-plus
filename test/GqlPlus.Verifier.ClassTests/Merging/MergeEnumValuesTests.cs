using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeEnumValuesTests
  : TestDescriptions<EnumValueAst>
{
  private readonly MergeEnumValues _merger = new();

  protected override DescribedMerger<EnumValueAst> MergerDescribed => _merger;

  protected override EnumValueAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}
