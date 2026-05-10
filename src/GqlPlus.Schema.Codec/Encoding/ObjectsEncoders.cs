namespace GqlPlus.Encoding;

internal class TypeArgEncoder(
  IEncoderRepository encoders
) : DescribedEncoder<ITypeArgModel>
{
  private readonly DeferOne<IEncoder<EnumValueModel>> _enumValue = encoders.EncoderFor<EnumValueModel>();

  internal override Structured Encode(ITypeArgModel model)
    => model.EnumValue is null
    ? base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Name?.Encode()),
        f => f.Add("name", model.Name?.Encode()))
    : _enumValue.I.Encode(model.EnumValue);

  internal static new TypeArgEncoder Factory(IEncoderRepository r) => new(r);
}

internal class ObjectBaseEncoder<TBase>(
  IEncoderRepository encoders
) : DescribedEncoder<TBase>
  where TBase : ObjBaseModel
{
  private readonly DeferOne<IEncoder<ITypeArgModel>> _objArg = encoders.EncoderFor<ITypeArgModel>();

  internal override Structured Encode(TBase model)
    => base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Name?.Encode()),
        f => f.Add("name", model.Name?.Encode())
          .AddList("typeArgs", model.Args, _objArg.I));

  internal static new ObjectBaseEncoder<TBase> Factory(IEncoderRepository r) => new(r);
}

internal class TypeParamEncoder(
  IEncoderRepository encoders
) : NamedEncoder<TypeParamModel>
{
  private readonly DeferOne<IEncoder<TypeRefModel<TypeKindModel>>> _typeKind = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(TypeParamModel model)
    => base.Encode(model)
      .AddEncoded("constraint", model.Constraint, _typeKind.I);

  internal static new TypeParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class ObjectFieldEncoder<TField, TBase>(
  IEncoderRepository encoders
) : AliasedEncoder<TField>
  where TField : IObjFieldModel
  where TBase : class, IObjBaseModel
{
  private readonly DeferOne<IEncoder<ModifierModel>> _modifier = encoders.EncoderFor<ModifierModel>();
  private readonly DeferOne<IEncoder<TBase>> _objBase = encoders.EncoderFor<TBase>();

  internal override Structured Encode(TField model)
    => base.Encode(model)
      .AddList("modifiers", model.Modifiers, _modifier.I, flow: true)
      .AddEncoded("type", model.BaseType as TBase, _objBase.I);
}

internal class ObjectAlternateEncoder(
  IEncoderRepository encoders
) : BaseEncoder<AlternateModel>()
{
  private readonly DeferOne<IEncoder<CollectionModel>> _collection = encoders.EncoderFor<CollectionModel>();
  private readonly DeferOne<IEncoder<ObjBaseModel>> _objBase = encoders.EncoderFor<ObjBaseModel>();

  internal override Structured Encode(AlternateModel model)
    => base.Encode(model)
      .AddEncoded("type", model.Type, _objBase.I)
      .AddList("collections", model.Collections, _collection.I);

  internal static ObjectAlternateEncoder Factory(IEncoderRepository r) => new(r);
}

internal class ObjectForEncoder<TFor>(
  IEncoderRepository encoders
) : BaseEncoder<ObjectForModel<TFor>>
  where TFor : IModelBase
{
  private readonly DeferOne<IEncoder<TFor>> _encoder = encoders.EncoderFor<TFor>();

  internal override Structured Encode(ObjectForModel<TFor> model)
    => base.Encode(model)
      .IncludeEncoded(model.For, _encoder.I)
      .Add("object", model.Obj?.Encode());

  internal static ObjectForEncoder<TFor> Factory(IEncoderRepository r) => new(r);
}

internal abstract class TypeObjectEncoder<TObject, TField>(
  IEncoderRepository encoders
) : ChildTypeEncoder<TObject, ObjBaseModel>(encoders)
  where TObject : TypeObjectModel<TField>
  where TField : IObjFieldModel
{
  private readonly DeferOne<IEncoder<TField>> _field = encoders.EncoderFor<TField>();
  private readonly DeferOne<IEncoder<ObjectForModel<TField>>> _forField = encoders.EncoderFor<ObjectForModel<TField>>();
  private readonly DeferOne<IEncoder<ObjectForModel<DualFieldModel>>> _dualField = encoders.EncoderFor<ObjectForModel<DualFieldModel>>();
  private readonly DeferOne<IEncoder<AlternateModel>> _alternate = encoders.EncoderFor<AlternateModel>();
  private readonly DeferOne<IEncoder<ObjectForModel<AlternateModel>>> _forAlternate = encoders.EncoderFor<ObjectForModel<AlternateModel>>();
  private readonly DeferOne<IEncoder<ObjectForModel<AlternateModel>>> _dualAlternate = encoders.EncoderFor<ObjectForModel<AlternateModel>>();
  private readonly DeferOne<IEncoder<TypeParamModel>> _typeParam = encoders.EncoderFor<TypeParamModel>();

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
        .AddList("typeParams", model.TypeParams, _typeParam.I)
        .AddList("fields", model.Fields, _field.I)
        .Add("allFields", ObjEncode(model.AllFields, _forField.I, _dualField.I))
        .AddList("alternates", model.Alternates, _alternate.I)
        .Add("allAlternates", ObjEncode(model.AllAlternates, _forAlternate.I, _dualAlternate.I));
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
  private readonly DeferOne<IEncoder<ConstantModel>> _constant = encoders.EncoderFor<ConstantModel>();

  internal override Structured Encode(InputFieldModel model)
    => base.Encode(model)
      .AddEncoded("default", model.Default, _constant.I);

  internal static new InputFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class InputParamEncoder(
  IEncoderRepository encoders
) : ObjectBaseEncoder<InputParamModel>(encoders)
{
  private readonly DeferOne<IEncoder<ModifierModel>> _modifier = encoders.EncoderFor<ModifierModel>();
  private readonly DeferOne<IEncoder<ConstantModel>> _constant = encoders.EncoderFor<ConstantModel>();

  internal override Structured Encode(InputParamModel model)
    => base.Encode(model)
      .AddList("modifiers", model.Modifiers, _modifier.I, flow: true)
      .AddEncoded("default", model.DefaultValue, _constant.I);

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
  private readonly DeferOne<IEncoder<OutputEnumModel>> _outputEnum = encoders.EncoderFor<OutputEnumModel>();
  private readonly DeferOne<IEncoder<InputParamModel>> _parameter = encoders.EncoderFor<InputParamModel>();

  internal override Structured Encode(OutputFieldModel model)
    => model.Enum is null
      ? base.Encode(model)
        .AddEncoded("parameter", model.Parameter, _parameter.I)
      : _outputEnum.I.Encode(model.Enum);

  internal static new OutputFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class TypeOutputEncoder(
  IEncoderRepository encoders
) : TypeObjectEncoder<TypeOutputModel, OutputFieldModel>(encoders)

{
  internal static new TypeOutputEncoder Factory(IEncoderRepository r) => new(r);
}
