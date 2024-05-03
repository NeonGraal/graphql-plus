using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Objects;

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
    var baseCanMerge = base.CanMergeGroup(group);
    var typeParametersCanMerge = group.ManyCanMerge(item => item.TypeParameters, typeParameters);
    var alternatesCanMerge = group.ManyGroupCanMerge(item => item.Alternates, a => a.Type.FullType, alternates);

    return baseCanMerge.Add(typeParametersCanMerge).Add(alternatesCanMerge);
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    var typeParametersAsts = group.ManyMerge(item => item.TypeParameters, typeParameters);
    var alternateAsts = group.ManyMerge(item => item.Alternates, alternates);

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
