using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeInputFields(
  ILoggerFactory logger
) : FieldsMerger<InputFieldAst, InputReferenceAst>(logger)
{
  public override bool CanMerge(IEnumerable<InputFieldAst> items)
    => base.CanMerge(items)
       && items.CanMerge(item => item.Default);
}
