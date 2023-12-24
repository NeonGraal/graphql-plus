using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeInputFields
  : FieldsMerger<InputFieldAst, InputReferenceAst>
{
  public override bool CanMerge(IEnumerable<InputFieldAst> items)
    => base.CanMerge(items)
       && items.CanMerge(item => item.Default);
}
