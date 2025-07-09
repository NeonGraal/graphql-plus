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
  IEncoder<TParent> parent
) : BaseTypeEncoder<TModel>
  where TModel : ChildTypeModel<TParent>
  where TParent : IModelBase
{
  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .AddEncoded("parent", model.Parent, parent);
}

internal record class ParentTypeEncoders<TItem, TAll>(
  IEncoder<TypeRefModel<SimpleKindModel>> Parent,
  IEncoder<TItem> Item,
  IEncoder<TAll> All
  ) where TItem : IModelBase
    where TAll : IModelBase;

internal abstract class ParentTypeEncoder<TModel, TItem, TAll>(
  ParentTypeEncoders<TItem, TAll> encoders
) : ChildTypeEncoder<TModel, TypeRefModel<SimpleKindModel>>(encoders.Parent)
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  internal override Structured Encode(TModel model)
    => base.Encode(model)
        .AddList("items", model.Items, encoders.Item)
        .AddList("allItems", model.AllItems, encoders.All);
}

internal class AllTypesEncoder(
  IEnumerable<ITypeEncoder> types
) : IEncoder<BaseTypeModel>
{
  Structured IEncoder<BaseTypeModel>.Encode(BaseTypeModel model)
    => types
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
  : DescribedEncoder<TModel>
  where TModel : TypeRefModel<TKind>
  where TKind : struct
{
  private static readonly string s_typeKindTag = typeof(TKind).TypeTag();

  internal override Structured Encode(TModel model)
    => base.Encode(model)
      .Add("typeName", model.TypeName)
      .Add("typeKind", new(model.TypeKind.ToString(), s_typeKindTag));
}

internal class SpecialTypeEncoder
  : BaseTypeEncoder<SpecialTypeModel>
{ }
