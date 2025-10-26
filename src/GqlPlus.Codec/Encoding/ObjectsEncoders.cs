namespace GqlPlus.Encoding;

internal class TypeArgEncoder(
  IEncoder<EnumValueModel> enumValue
) : DescribedEncoder<TypeArgModel>
{
  internal override Structured Encode(TypeArgModel model)
    => model.EnumValue is null
    ? base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Name),
        f => f.Add("name", model.Name))
    : enumValue.Encode(model.EnumValue);
}

internal class ObjectBaseEncoder<TBase>(
  IEncoder<TypeArgModel> objArg
) : DescribedEncoder<TBase>
  where TBase : ObjBaseModel
{
  internal override Structured Encode(TBase model)
    => base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Name),
        f => f.Add("name", model.Name)
          .AddList("typeArgs", model.Args, objArg));
}

internal class TypeParamEncoder(
  IEncoder<TypeRefModel<TypeKindModel>> typeKind
) : NamedEncoder<TypeParamModel>
{
  internal override Structured Encode(TypeParamModel model)
    => base.Encode(model)
      .AddEncoded("constraint", model.Constraint, typeKind);
}

internal record class FieldEncoders<TBase>(
  IEncoder<ModifierModel> Modifier,
  IEncoder<TBase> ObjBase
) where TBase : IObjBaseModel;

internal class ObjectFieldEncoder<TField, TBase>(
  FieldEncoders<TBase> encoders
) : AliasedEncoder<TField>
  where TField : IObjFieldModel
  where TBase : class, IObjBaseModel
{
  internal override Structured Encode(TField model)
    => base.Encode(model)
      .AddList("modifiers", model.Modifiers, encoders.Modifier, flow: true)
      .AddEncoded("type", model.BaseType as TBase, encoders.ObjBase);
}

internal record class AlternateEncoders<TObjBase>(
  IEncoder<CollectionModel> Collection,
  IEncoder<TObjBase> ObjBase
) where TObjBase : IObjBaseModel;

internal class ObjectAlternateEncoder(
  AlternateEncoders<ObjBaseModel> encoders
) : BaseEncoder<AlternateModel>()
{
  internal override Structured Encode(AlternateModel model)
    => base.Encode(model)
      .AddEncoded("type", model.Type, encoders.ObjBase)
      .AddList("collections", model.Collections, encoders.Collection);
}

internal class ObjectForEncoder<TFor>(
  IEncoder<TFor> encoder
) : BaseEncoder<ObjectForModel<TFor>>
  where TFor : IModelBase
{
  internal override Structured Encode(ObjectForModel<TFor> model)
    => base.Encode(model)
      .IncludeEncoded(model.For, encoder)
      .Add("object", model.Obj);
}

internal record class TypeObjectEncoders<TField>(
  IEncoder<ObjBaseModel> Parent,
  IEncoder<TField> Field,
  IEncoder<ObjectForModel<TField>> ForField,
  IEncoder<ObjectForModel<DualFieldModel>> DualField,
  IEncoder<AlternateModel> Alternate,
  IEncoder<ObjectForModel<AlternateModel>> ForAlternate,
  IEncoder<ObjectForModel<AlternateModel>> DualAlternate,
  IEncoder<TypeParamModel> TypeParam
)
  where TField : IObjFieldModel;

internal abstract class TypeObjectEncoder<TObject, TField>(
  TypeObjectEncoders<TField> encoders
) : ChildTypeEncoder<TObject, ObjBaseModel>(encoders.Parent)
  where TObject : TypeObjectModel<TField>
  where TField : IObjFieldModel
{
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
        .AddList("typeParams", model.TypeParams, encoders.TypeParam)
        .AddList("fields", model.Fields, encoders.Field)
        .Add("allFields", ObjEncode(model.AllFields, encoders.ForField, encoders.DualField))
        .AddList("alternates", model.Alternates, encoders.Alternate)
        .Add("allAlternates", ObjEncode(model.AllAlternates, encoders.ForAlternate, encoders.DualAlternate));
  }
}

internal class DualFieldEncoder(
  FieldEncoders<ObjBaseModel> encoders
) : ObjectFieldEncoder<DualFieldModel, ObjBaseModel>(encoders)
{ }

internal class TypeDualEncoder(
  TypeObjectEncoders<DualFieldModel> encoders
) : TypeObjectEncoder<TypeDualModel, DualFieldModel>(encoders)
{ }

internal class InputFieldEncoder(
  IEncoder<ConstantModel> constant,
  FieldEncoders<ObjBaseModel> encoders
) : ObjectFieldEncoder<InputFieldModel, ObjBaseModel>(encoders)
{
  internal override Structured Encode(InputFieldModel model)
    => base.Encode(model)
      .AddEncoded("default", model.Default, constant);
}

internal class InputParamEncoder(
  IEncoder<TypeArgModel> objArg,
  IEncoder<ModifierModel> modifier,
  IEncoder<ConstantModel> constant
) : ObjectBaseEncoder<InputParamModel>(objArg)
{
  internal override Structured Encode(InputParamModel model)
    => base.Encode(model)
      .AddList("modifiers", model.Modifiers, modifier, flow: true)
      .AddEncoded("default", model.DefaultValue, constant);
}

internal class TypeInputEncoder(
  TypeObjectEncoders<InputFieldModel> encoders
) : TypeObjectEncoder<TypeInputModel, InputFieldModel>(encoders)
{ }

internal class OutputEnumEncoder
  : TypeRefEncoder<OutputEnumModel, SimpleKindModel>
{
  internal override Structured Encode(OutputEnumModel model)
    => base.Encode(model)
      .Add("field", model.Field)
      .Add("label", model.EnumLabel);
}

internal class OutputFieldEncoder(
  IEncoder<OutputEnumModel> outputEnum,
  FieldEncoders<ObjBaseModel> encoders,
  IEncoder<InputParamModel> parameter
) : ObjectFieldEncoder<OutputFieldModel, ObjBaseModel>(encoders)
{
  internal override Structured Encode(OutputFieldModel model)
    => model.Enum is null
      ? base.Encode(model)
        .AddList("parameters", model.Params, parameter)
      : outputEnum.Encode(model.Enum);
}

internal class TypeOutputEncoder(
  TypeObjectEncoders<OutputFieldModel> encoders
) : TypeObjectEncoder<TypeOutputModel, OutputFieldModel>(encoders)
{ }
