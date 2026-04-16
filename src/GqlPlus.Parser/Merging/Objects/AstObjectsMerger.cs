using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class AstObjectsMerger<TObjField>(
  IMergerRepository mergers
) : AstTypeMerger<IAstType, IAstObject<TObjField>, IAstObjBase, TObjField>(mergers)
  where TObjField : IAstObjField
{
  private readonly IMerge<IAstTypeParam> _typeParams = mergers.MergerFor<IAstTypeParam>();
  private readonly IMerge<IAstAlternate> _alternates = mergers.MergerFor<IAstAlternate>();

  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(IAstObject<TObjField> item)
    => (item.Parent?.FullType).IfWhiteSpace();

  protected override IMessages CanMergeGroup(IGrouping<string, IAstObject<TObjField>> group)
  {
    IMessages baseCanMerge = base.CanMergeGroup(group);
    IMessages typeParamsCanMerge = group.ManyCanMerge(item => item.TypeParams, _typeParams);
    IMessages alternatesCanMerge = group.ManyGroupCanMerge(item => item.Alternates, a => a.FullType, _alternates);

    return baseCanMerge.Add(typeParamsCanMerge).Add(alternatesCanMerge);
  }

  protected override IAstObject<TObjField> MergeGroup(IEnumerable<IAstObject<TObjField>> group)
  {
    IEnumerable<IAstTypeParam> typeParamsAsts = group.ManyMerge(item => item.TypeParams, _typeParams);
    IEnumerable<IAstAlternate> alternateAsts = group.ManyMerge(item => item.Alternates, _alternates);

    return SetAlternates(base.MergeGroup(group), typeParamsAsts, alternateAsts);
  }

  [SuppressMessage("Performance", "CA1822:Mark members as static")]
  protected AstObject<TObjField> SetAlternates(IAstObject<TObjField> obj, IEnumerable<IAstTypeParam> typeParams, IEnumerable<IAstAlternate> alternates)
    => (AstObject<TObjField>)obj with {
      TypeParams = typeParams.ArrayOf<TypeParamAst>(),
      Alternates = [.. alternates],
    };

  internal override IEnumerable<TObjField> GetItems(IAstObject<TObjField> type)
    => type.ObjFields;

  internal override IAstObject<TObjField> SetItems(IAstObject<TObjField> input, IEnumerable<TObjField> items)
    => (AstObject<TObjField>)input with {
      ObjFields = [.. items],
    };

  internal static AstObjectsMerger<TObjField> Factory(IMergerRepository m) => new(m);
}
