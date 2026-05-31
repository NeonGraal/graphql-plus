namespace GqlPlus.Encoding;

internal class TypeArgEncoder(
  IEncoderRepository encoders
) : DescribedEncoder<ITypeArgModel>
{
  private readonly Encoder<EnumValueModel> _enumValue = encoders.EncoderFor<EnumValueModel>();

  internal override Structured Encode(ITypeArgModel model)
    => base.Encode(model)
      .AddNull(model.EnumValue,
        v => v.AddEncoded("enumValue", model.EnumValue, _enumValue),
        f => f
          .AddIf(model.IsTypeParam,
            t => t.Add("typeParam", model.Name?.Encode()),
            f => f.Add("name", model.Name?.Encode())));

  internal static TypeArgEncoder Factory(IEncoderRepository r) => new(r);
}

internal class ObjectBaseEncoder<TBase>(
  IEncoderRepository encoders
) : DescribedEncoder<TBase>
  where TBase : ObjBaseModel
{
  private readonly Encoder<ITypeArgModel> _objArg = encoders.EncoderFor<ITypeArgModel>();

  internal override Structured Encode(TBase model)
    => base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Name?.Encode()),
        f => f.Add("name", model.Name?.Encode())
          .AddList("typeArgs", model.Args, _objArg));

  internal static ObjectBaseEncoder<TBase> Factory(IEncoderRepository r) => new(r);
}

internal class TypeParamEncoder(
  IEncoderRepository encoders
) : NamedEncoder<TypeParamModel>
{
  private readonly Encoder<TypeRefModel<TypeKindModel>> _typeKind = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(TypeParamModel model)
    => base.Encode(model)
      .AddEncoded("constraint", model.Constraint, _typeKind);

  internal static TypeParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class ObjectFieldEncoder<TField, TBase>(
  IEncoderRepository encoders
) : AliasedEncoder<TField>
  where TField : IObjFieldModel
  where TBase : class, IObjBaseModel
{
  private readonly Encoder<ModifierModel> _modifier = encoders.EncoderFor<ModifierModel>();
  private readonly Encoder<TBase> _objBase = encoders.EncoderFor<TBase>();

  internal override Structured Encode(TField model)
    => base.Encode(model)
      .AddList("modifiers", model.Modifiers, _modifier, flow: true)
      .AddEncoded("type", model.BaseType as TBase, _objBase);
}

internal class ObjectAlternateEncoder(
  IEncoderRepository encoders
) : BaseEncoder<AlternateModel>()
{
  private readonly Encoder<CollectionModel> _collection = encoders.EncoderFor<CollectionModel>();
  private readonly Encoder<ObjBaseModel> _objBase = encoders.EncoderFor<ObjBaseModel>();

  internal override Structured Encode(AlternateModel model)
    => base.Encode(model)
      .AddEncoded("type", model.Type, _objBase)
      .AddList("collections", model.Collections, _collection);

  internal static ObjectAlternateEncoder Factory(IEncoderRepository r) => new(r);
}

internal class ObjectForEncoder<TFor>(
  IEncoderRepository encoders
) : BaseEncoder<ObjectForModel<TFor>>
  where TFor : IModelBase
{
  private readonly Encoder<TFor> _encoder = encoders.EncoderFor<TFor>();

  internal override Structured Encode(ObjectForModel<TFor> model)
    => base.Encode(model)
      .IncludeEncoded(model.For, _encoder)
      .Add("object", model.Obj?.Encode());

  internal static ObjectForEncoder<TFor> Factory(IEncoderRepository r) => new(r);
}

internal abstract class TypeObjectEncoder<TObject, TField>(
  IEncoderRepository encoders
) : ChildTypeEncoder<TObject, ObjBaseModel>(encoders)
  where TObject : TypeObjectModel<TField>
  where TField : IObjFieldModel
{
  private readonly Encoder<TField> _field = encoders.EncoderFor<TField>();
  private readonly Encoder<ObjectForModel<TField>> _forField = encoders.EncoderFor<ObjectForModel<TField>>();
  private readonly Encoder<ObjectForModel<DualFieldModel>> _dualField = encoders.EncoderFor<ObjectForModel<DualFieldModel>>();
  private readonly Encoder<AlternateModel> _alternate = encoders.EncoderFor<AlternateModel>();
  private readonly Encoder<ObjectForModel<AlternateModel>> _forAlternate = encoders.EncoderFor<ObjectForModel<AlternateModel>>();
  private readonly Encoder<ObjectForModel<AlternateModel>> _dualAlternate = encoders.EncoderFor<ObjectForModel<AlternateModel>>();
  private readonly Encoder<TypeParamModel> _typeParam = encoders.EncoderFor<TypeParamModel>();

  internal override Structured Encode(TObject model)
  {
    Structured ObjEncode<TModel, TDual>(ModelBase[] list, IEncoder<ObjectForModel<TModel>> encoder, IEncoder<ObjectForModel<TDual>> dual)
      where TModel : IModelBase
      where TDual : ModelBase
      => list.Encode(o => o switch {
        ObjectForModel<TModel> modelFor => encoder.Encode(modelFor),
        ObjectForModel<TDual> dualFor => dual.Encode(dualFor),
        _ => throw new InvalidCastException("Invalid ObjectFor " + o.GetType().ExpandTypeName() + " in " + model.Name
            + " expected " + typeof(TModel).ExpandTypeName() + " or " + typeof(TDual).ExpandTypeName())
      });

    return base.Encode(model)
        .AddList("typeParams", model.TypeParams, _typeParam)
        .AddList("fields", model.Fields, _field)
        .Add("allFields", ObjEncode(model.AllFields, _forField, _dualField))
        .AddList("alternates", model.Alternates, _alternate)
        .Add("allAlternates", ObjEncode(model.AllAlternates, _forAlternate, _dualAlternate));
  }
}

internal class DualFieldEncoder(
  IEncoderRepository encoders
) : ObjectFieldEncoder<DualFieldModel, ObjBaseModel>(encoders)

{
  internal static DualFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class TypeDualEncoder(
  IEncoderRepository encoders
) : TypeObjectEncoder<TypeDualModel, DualFieldModel>(encoders)

{
  internal static TypeDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class InputFieldEncoder(
  IEncoderRepository encoders
) : ObjectFieldEncoder<InputFieldModel, ObjBaseModel>(encoders)
{
  private readonly Encoder<ConstantModel> _constant = encoders.EncoderFor<ConstantModel>();

  internal override Structured Encode(InputFieldModel model)
    => base.Encode(model)
      .AddEncoded("default", model.Default, _constant);

  internal static InputFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class InputParamEncoder(
  IEncoderRepository encoders
) : ObjectBaseEncoder<InputParamModel>(encoders)
{
  private readonly Encoder<ModifierModel> _modifier = encoders.EncoderFor<ModifierModel>();
  private readonly Encoder<ConstantModel> _constant = encoders.EncoderFor<ConstantModel>();

  internal override Structured Encode(InputParamModel model)
    => base.Encode(model)
      .AddList("modifiers", model.Modifiers, _modifier, flow: true)
      .AddEncoded("default", model.DefaultValue, _constant);

  internal static new InputParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class TypeInputEncoder(
  IEncoderRepository encoders
) : TypeObjectEncoder<TypeInputModel, InputFieldModel>(encoders)

{
  internal static TypeInputEncoder Factory(IEncoderRepository r) => new(r);
}

internal class OutputEnumEncoder
  : TypeRefEncoder<OutputEnumModel, SimpleKindModel>
{
  internal override Structured Encode(OutputEnumModel model)
    => base.Encode(model)
      .Add("field", model.Field?.Encode())
      .Add("label", model.EnumLabel?.Encode());

  internal static new OutputEnumEncoder Factory(IEncoderRepository _) => new();
}

internal class OutputFieldEncoder(
  IEncoderRepository encoders
) : ObjectFieldEncoder<OutputFieldModel, ObjBaseModel>(encoders)
{
  private readonly Encoder<OutputEnumModel> _outputEnum = encoders.EncoderFor<OutputEnumModel>();
  private readonly Encoder<InputParamModel> _parameter = encoders.EncoderFor<InputParamModel>();

  internal override Structured Encode(OutputFieldModel model)
    => base.Encode(model)
     .AddNull(model.Enum,
       v => v.AddEncoded("enum", model.Enum, _outputEnum),
       f => f.AddEncoded("parameter", model.Parameter, _parameter));

  internal static OutputFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class TypeOutputEncoder(
  IEncoderRepository encoders
) : TypeObjectEncoder<TypeOutputModel, OutputFieldModel>(encoders)

{
  internal static TypeOutputEncoder Factory(IEncoderRepository r) => new(r);
}
