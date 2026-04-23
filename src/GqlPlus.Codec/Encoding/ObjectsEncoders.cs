namespace GqlPlus.Encoding;

internal class TypeArgEncoder(
  IEncoderRepository encoders
) : DescribedEncoder<TypeArgModel>
{
  private readonly IEncoder<EnumValueModel> _enumValue = encoders.EncoderFor<EnumValueModel>();

  internal override Structured Encode(TypeArgModel model)
    => model.EnumValue is null
    ? base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Name?.Encode()),
        f => f.Add("name", model.Name?.Encode()))
    : _enumValue.Encode(model.EnumValue);

  internal static new TypeArgEncoder Factory(IEncoderRepository r) => new(r);
}

internal class ObjectBaseEncoder<TBase>(
  IEncoderRepository encoders
) : DescribedEncoder<TBase>
  where TBase : ObjBaseModel
{
  private readonly IEncoder<TypeArgModel> _objArg = encoders.EncoderFor<TypeArgModel>();

  internal override Structured Encode(TBase model)
    => base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Name?.Encode()),
        f => f.Add("name", model.Name?.Encode())
          .AddList("typeArgs", model.Args, _objArg));

  internal static new ObjectBaseEncoder<TBase> Factory(IEncoderRepository r) => new(r);
}

internal class TypeParamEncoder(
  IEncoderRepository encoders
) : NamedEncoder<TypeParamModel>
{
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _typeKind = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(TypeParamModel model)
    => base.Encode(model)
      .AddEncoded("constraint", model.Constraint, _typeKind);

  internal static new TypeParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class ObjectFieldEncoder<TField, TBase>(
  IEncoderRepository encoders
) : AliasedEncoder<TField>
  where TField : IObjFieldModel
  where TBase : class, IObjBaseModel
{
  private readonly IEncoder<ModifierModel> _modifier = encoders.EncoderFor<ModifierModel>();
  private readonly IEncoder<TBase> _objBase = encoders.EncoderFor<TBase>();

  internal override Structured Encode(TField model)
    => base.Encode(model)
      .AddList("modifiers", model.Modifiers, _modifier, flow: true)
      .AddEncoded("type", model.BaseType as TBase, _objBase);
}

internal class ObjectAlternateEncoder(
  IEncoderRepository encoders
) : BaseEncoder<AlternateModel>()
{
  private readonly IEncoder<CollectionModel> _collection = encoders.EncoderFor<CollectionModel>();
  private readonly IEncoder<ObjBaseModel> _objBase = encoders.EncoderFor<ObjBaseModel>();

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
  private readonly IEncoder<TFor> _encoder = encoders.EncoderFor<TFor>();

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
  private readonly IEncoder<TField> _field = encoders.EncoderFor<TField>();
  private readonly IEncoder<ObjectForModel<TField>> _forField = encoders.EncoderFor<ObjectForModel<TField>>();
  private readonly IEncoder<ObjectForModel<DualFieldModel>> _dualField = encoders.EncoderFor<ObjectForModel<DualFieldModel>>();
  private readonly IEncoder<AlternateModel> _alternate = encoders.EncoderFor<AlternateModel>();
  private readonly IEncoder<ObjectForModel<AlternateModel>> _forAlternate = encoders.EncoderFor<ObjectForModel<AlternateModel>>();
  private readonly IEncoder<ObjectForModel<AlternateModel>> _dualAlternate = encoders.EncoderFor<ObjectForModel<AlternateModel>>();
  private readonly IEncoder<TypeParamModel> _typeParam = encoders.EncoderFor<TypeParamModel>();

  internal override Structured Encode(TObject model)
  {
    Structured ObjEncode<TModel, TDual>(ModelBase[] list, IEncoder<ObjectForModel<TModel>> encoder, IEncoder<ObjectForModel<TDual>> dual)
      where TModel : IModelBase
      where TDual : ModelBase
      => new(list.Select(o => o switch {
        ObjectForModel<TModel> modelFor => encoder.Encode(modelFor),
        ObjectForModel<TDual> dualFor => dual.Encode(dualFor),
        _ => throw new InvalidCastException("Invalid ObjectFor " + o.GetType().ExpandTypeName() + " in " + model.Name
            + " expected " + typeof(TModel).ExpandTypeName() + " or " + typeof(TDual).ExpandTypeName())
      }));

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
  internal static new DualFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class TypeDualEncoder(
  IEncoderRepository encoders
) : TypeObjectEncoder<TypeDualModel, DualFieldModel>(encoders)

{
  internal static new TypeDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class InputFieldEncoder(
  IEncoderRepository encoders
) : ObjectFieldEncoder<InputFieldModel, ObjBaseModel>(encoders)
{
  private readonly IEncoder<ConstantModel> _constant = encoders.EncoderFor<ConstantModel>();

  internal override Structured Encode(InputFieldModel model)
    => base.Encode(model)
      .AddEncoded("default", model.Default, _constant);

  internal static new InputFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class InputParamEncoder(
  IEncoderRepository encoders
) : ObjectBaseEncoder<InputParamModel>(encoders)
{
  private readonly IEncoder<ModifierModel> _modifier = encoders.EncoderFor<ModifierModel>();
  private readonly IEncoder<ConstantModel> _constant = encoders.EncoderFor<ConstantModel>();

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
  internal static new TypeInputEncoder Factory(IEncoderRepository r) => new(r);
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
  private readonly IEncoder<OutputEnumModel> _outputEnum = encoders.EncoderFor<OutputEnumModel>();
  private readonly IEncoder<InputParamModel> _parameter = encoders.EncoderFor<InputParamModel>();

  internal override Structured Encode(OutputFieldModel model)
    => model.Enum is null
      ? base.Encode(model)
        .AddEncoded("parameter", model.Parameter, _parameter)
      : _outputEnum.Encode(model.Enum);

  internal static new OutputFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class TypeOutputEncoder(
  IEncoderRepository encoders
) : TypeObjectEncoder<TypeOutputModel, OutputFieldModel>(encoders)

{
  internal static new TypeOutputEncoder Factory(IEncoderRepository r) => new(r);
}
