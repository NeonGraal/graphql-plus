using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class AstObjectsMerger<TObject, TObjField, TObjBase>(
  ILoggerFactory logger,
  IMerge<TObjField> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<TObjBase>> alternates
) : AstTypeMerger<AstType, TObject, TObjBase, TObjField>(logger, fields)
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>, IAstDescribed
  where TObjBase : AstObjectBase<TObjBase>
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(TObject item)
    => item.Parent?.Name ?? "";

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TObject> group)
  {
    ITokenMessages baseCanMerge = base.CanMergeGroup(group);
    ITokenMessages typeParametersCanMerge = group.ManyCanMerge(item => item.TypeParameters, typeParameters);
    ITokenMessages alternatesCanMerge = group.ManyGroupCanMerge(item => item.Alternates, a => a.Type.FullType, alternates);

    return baseCanMerge.Add(typeParametersCanMerge).Add(alternatesCanMerge);
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    IEnumerable<TypeParameterAst> typeParametersAsts = group.ManyMerge(item => item.TypeParameters, typeParameters);
    IEnumerable<AstAlternate<TObjBase>> alternateAsts = group.ManyMerge(item => item.Alternates, alternates);

    return base.MergeGroup(group) with {
      TypeParameters = [.. typeParametersAsts],
      Alternates = [.. alternateAsts],
    };
  }

  internal override IEnumerable<TObjField> GetItems(TObject type)
    => type.Fields;
  internal override TObject SetItems(TObject input, IEnumerable<TObjField> items)
    => input with { Fields = [.. items] };
}
