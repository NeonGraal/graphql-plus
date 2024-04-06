using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeInputFields(
  ILoggerFactory logger
) : FieldsMerger<InputFieldAst, InputReferenceAst>(logger)
{
  public override ITokenMessages CanMerge(IEnumerable<InputFieldAst> items)
    => base.CanMerge(items)
      .Add(items.CanMerge(item => item.Default));
}
