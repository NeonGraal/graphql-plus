namespace GqlPlus.Encoding;

internal class ObjectBaseEncoder<TBase, TArg>(
  IEncoder<TArg> objArg
) : DescribedEncoder<TBase>
  where TBase : ObjBaseModel<TArg>
  where TArg : IObjTypeArgModel
{
  internal override Structured Encode(TBase model)
    => base.Encode(model)
      .AddIf(model.IsTypeParam, onFalse: s => s.AddList("typeArgs", model.Args, objArg));
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

internal class ObjectAlternateEncoder<TAlt, TObjBase>(
  AlternateEncoders<TObjBase> encoders
) : BaseEncoder<TAlt>()
  where TAlt : ObjAlternateModel<TObjBase>
  where TObjBase : IObjBaseModel
{
  internal override Structured Encode(TAlt model)
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

internal record class TypeObjectEncoders<TBase, TField, TAlt>(
  IEncoder<TBase> Parent,
  IEncoder<TField> Field,
  IEncoder<ObjectForModel<TField>> ObjField,
  IEncoder<ObjectForModel<DualFieldModel>> DualField,
  IEncoder<TAlt> Alternate,
  IEncoder<ObjectForModel<TAlt>> ObjAlternate,
  IEncoder<ObjectForModel<DualAlternateModel>> DualAlternate,
  IEncoder<TypeParamModel> TypeParam
)
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel;

internal abstract class TypeObjectEncoder<TObject, TBase, TField, TAlt>(
  TypeObjectEncoders<TBase, TField, TAlt> encoders
) : ChildTypeEncoder<TObject, TBase>(encoders.Parent)
  where TObject : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
{
  internal override Structured Encode(TObject model)
  {
    List<ModelBase> allAlternates = [];
    List<ModelBase> allFields = [];

    //void AddMembers(ITypeObjectModel model)
    //{
    //  allAlternates.AddRange(model.AllAlternates);
    //  allFields.AddRange(model.AllFields);
    //}

    //ForParent<TObject, ITypeObjectModel>(model, context, AddMembers);
    // AddMembers(model);

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
        .Add("allFields", ObjEncode(model.AllFields, encoders.ObjField, encoders.DualField))
        .AddList("alternates", model.Alternates, encoders.Alternate)
        .Add("allAlternates", ObjEncode(model.AllAlternates, encoders.ObjAlternate, encoders.DualAlternate));
  }
}

internal class DualArgEncoder
  : DescribedEncoder<DualArgModel>
{
  internal override Structured Encode(DualArgModel model)
    => base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Dual),
        f => f.Add("dual", model.Dual));
}

internal class DualBaseEncoder(
  IEncoder<DualArgModel> objArg
) : ObjectBaseEncoder<DualBaseModel, DualArgModel>(objArg)
{
  internal override Structured Encode(DualBaseModel model)
    => base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Dual),
        f => f.Add("dual", model.Dual));
}

internal class DualFieldEncoder(
  FieldEncoders<DualBaseModel> encoders
) : ObjectFieldEncoder<DualFieldModel, DualBaseModel>(encoders)
{ }

internal class TypeDualEncoder(
  TypeObjectEncoders<DualBaseModel, DualFieldModel, DualAlternateModel> encoders
) : TypeObjectEncoder<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>(encoders)
{ }

internal class InputArgEncoder(
  IEncoder<DualArgModel> dual
) : DescribedEncoder<InputArgModel>
{
  internal override Structured Encode(InputArgModel model)
    => model.Dual is null
    ? base.Encode(model)
      .AddIf(model.IsTypeParam,
        t => t.Add("typeParam", model.Input),
        f => f.Add("input", model.Input))
    : dual.Encode(model.Dual);
}

internal class InputDualEncoder<TObj>(
  IEncoder<InputArgModel> objArg,
  IEncoder<DualBaseModel> dual
) : ObjectBaseEncoder<TObj, InputArgModel>(objArg)
  where TObj : InputBaseModel
{
  internal override Structured Encode(TObj model)
    => model.Dual is null
      ? base.Encode(model)
        .AddIf(model.IsTypeParam,
          t => t.Add("typeParam", model.Input),
          f => f.Add("input", model.Input))
      : dual.Encode(model.Dual);
}

internal class InputBaseEncoder(
  IEncoder<InputArgModel> objArg,
  IEncoder<DualBaseModel> dual
) : InputDualEncoder<InputBaseModel>(objArg, dual)
{ }

internal class InputFieldEncoder(
  IEncoder<ConstantModel> constant,
  FieldEncoders<InputBaseModel> encoders
) : ObjectFieldEncoder<InputFieldModel, InputBaseModel>(encoders)
{
  internal override Structured Encode(InputFieldModel model)
    => base.Encode(model)
      .AddEncoded("default", model.Default, constant);
}

internal class InputParamEncoder(
  IEncoder<InputArgModel> objArg,
  IEncoder<DualBaseModel> dual,
  IEncoder<ModifierModel> modifier,
  IEncoder<ConstantModel> constant
) : InputDualEncoder<InputParamModel>(objArg, dual)
{
  internal override Structured Encode(InputParamModel model)
    => base.Encode(model)
      .AddList("modifiers", model.Modifiers, modifier, flow: true)
      .AddEncoded("default", model.DefaultValue, constant);
}

internal class TypeInputEncoder(
  TypeObjectEncoders<InputBaseModel, InputFieldModel, InputAlternateModel> encoders
) : TypeObjectEncoder<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>(encoders)
{ }

internal class OutputArgEncoder(
  IEncoder<DualArgModel> dual,
  IEncoder<TypeRefModel<SimpleKindModel>> label
) : DescribedEncoder<OutputArgModel>
{
  internal override Structured Encode(OutputArgModel model)
    => string.IsNullOrWhiteSpace(model.ThrowIfNull().EnumLabel)
    ? model.Dual is null
      ? base.Encode(model)
        .AddIf(model.IsTypeParam,
          t => t.Add("typeParam", model.Output ?? model.Name),
          f => f.Add("output", model.Output ?? model.Name))
      : dual.Encode(model.Dual)
    : label.Encode(model)
      .Add("label", model.EnumLabel!);
}

internal class OutputBaseEncoder(
  IEncoder<OutputArgModel> objArg,
  IEncoder<DualBaseModel> dual
) : ObjectBaseEncoder<OutputBaseModel, OutputArgModel>(objArg)
{
  internal override Structured Encode(OutputBaseModel model)
    => model.Dual is null
      ? base.Encode(model)
        .AddIf(model.IsTypeParam,
          t => t.Add("typeParam", model.Output),
          f => f.Add("output", model.Output))
      : dual.Encode(model.Dual);
}

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
  FieldEncoders<OutputBaseModel> encoders,
  IEncoder<InputParamModel> parameter
) : ObjectFieldEncoder<OutputFieldModel, OutputBaseModel>(encoders)
{
  internal override Structured Encode(OutputFieldModel model)
    => model.Enum is null
      ? base.Encode(model)
        .AddList("parameters", model.Params, parameter)
      : outputEnum.Encode(model.Enum);
}

internal class TypeOutputEncoder(
  TypeObjectEncoders<OutputBaseModel, OutputFieldModel, OutputAlternateModel> encoders
) : TypeObjectEncoder<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>(encoders)
{ }
