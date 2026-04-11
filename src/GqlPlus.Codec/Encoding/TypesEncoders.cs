namespace GqlPlus.Encoding;

internal class BaseTypeEncoder<TModel>
  : AliasedEncoder<TModel>
  , ITypeEncoder
  where TModel : BaseTypeModel
{
  public bool ForType(BaseTypeModel model)
    => model is TModel;

  public Structured TypeEncode(BaseTypeModel model)
    => Encode((TModel)model);

  internal override Structured Encode(TModel model)
    => base.Encode(model)
    .Add("typeKind", model.TypeKind.EncodeEnum());
}

internal abstract class ChildTypeEncoder<TModel, TParent>(
  IEncoderRepository encoders
) : BaseTypeEncoder<TModel>
  where TModel : ChildTypeModel<TParent>
  where TParent : IModelBase
{
  private readonly IEncoder<TParent> _parent = encoders.EncoderFor<TParent>();

  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .AddEncoded("parent", model.Parent, _parent);
}

internal abstract class ParentTypeEncoder<TModel, TItem, TAll>(
  IEncoderRepository encoders
) : ChildTypeEncoder<TModel, TypeRefModel<SimpleKindModel>>(encoders)
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  private readonly IEncoder<TItem> _item = encoders.EncoderFor<TItem>();
  private readonly IEncoder<TAll> _all = encoders.EncoderFor<TAll>();

  internal override Structured Encode(TModel model)
    => base.Encode(model)
        .AddList("items", model.Items, _item)
        .AddList("allItems", model.AllItems, _all);
}

internal class AllTypesEncoder(
  IEncoderRepository encoders
) : IEncoder<BaseTypeModel>
{
  Structured IEncoder<BaseTypeModel>.Encode(BaseTypeModel model)
    => encoders.TypeEncoders
    .SingleOrDefault(t => t.ForType(model))
    ?.TypeEncode(model)
    ?? throw new InvalidOperationException("Unable to find Encoder for " + model.GetType().ExpandTypeName());
}

public interface ITypeEncoder
{
  bool ForType(BaseTypeModel model);
  Structured TypeEncode(BaseTypeModel model);
}

internal class TypeRefEncoder<TModel, TKind>
  : NamedEncoder<TModel>
  where TModel : TypeRefModel<TKind>
  where TKind : Enum
{
  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .AddEnum("typeKind", model.TypeKind);
}

internal class DomainRefEncoder
  : TypeRefEncoder<DomainRefModel, SimpleKindModel>
{
  internal override Structured Encode(DomainRefModel model)
    => base.Encode(model)
      .AddEnum("domainKind", model.DomainKind);
}

internal class SpecialTypeEncoder
  : BaseTypeEncoder<SpecialTypeModel>
{ }
