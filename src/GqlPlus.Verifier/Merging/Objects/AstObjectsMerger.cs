using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Objects;

internal class AstObjectsMerger<TObject, TField, TRef>(
  ILoggerFactory logger,
  IMerge<TField> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<TRef>> alternates
) : AstTypeMerger<AstType, TObject, TRef, TField>(logger, fields)
  where TObject : AstObject<TField, TRef>
  where TField : AstObjectField<TRef>, IAstDescribed
  where TRef : AstReference<TRef>
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

  internal override IEnumerable<TField> GetItems(TObject type)
    => type.Fields;
  internal override TObject SetItems(TObject input, IEnumerable<TField> items)
    => input with { Fields = [.. items] };
}
