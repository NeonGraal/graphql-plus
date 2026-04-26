using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Simple;

internal abstract class AstSimpleMerger<TAst, TType, TItem>(
  IMergerRepository mergers
) : AstTypeMerger<TAst, TType, IAstTypeRef, TItem>(mergers)
  where TAst : IAstType
  where TType : IAstSimple<TItem>, TAst
  where TItem : IAstError
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(TType item)
    => (item.Parent?.Name).IfWhiteSpace();

  internal sealed override IEnumerable<TItem> GetItems(TType type)
    => type.Items;
}
