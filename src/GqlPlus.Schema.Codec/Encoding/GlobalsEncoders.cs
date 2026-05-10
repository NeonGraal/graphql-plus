namespace GqlPlus.Encoding;

internal class AndTypeEncoder<TModel, TAnd>(
  string field,
  IEncoderRepository encoders
) : BaseEncoder<TModel>
  where TModel : AndTypeModel<TAnd>
  where TAnd : ModelBase
{
  private readonly string _field = field;
  private readonly Defer<IEncoder<TAnd>>.L _and = encoders.EncoderFor<TAnd>();
  private readonly Defer<IEncoder<BaseTypeModel>>.L _type = encoders.EncoderFor<BaseTypeModel>();

  internal override Structured Encode(TModel model)
    => model.Type is null
      ? model.And is null
        ? "".Encode()
        : _and.I.Encode(model.And)
      : model.And is null
        ? _type.I.Encode(model.Type)
        : base.Encode(model)
          .AddEncoded(_field, model.And, _and.I)
          .AddEncoded("type", model.Type, _type.I);
}

internal class CategoriesEncoder(
  IEncoderRepository encoders
) : AndTypeEncoder<CategoriesModel, CategoryModel>("category", encoders)

{
  internal static CategoriesEncoder Factory(IEncoderRepository r) => new(r);
}

internal class CategoryEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<CategoryModel>
{
  private readonly Defer<IEncoder<ModifierModel>>.L _modifiers = encoders.EncoderFor<ModifierModel>();
  private readonly Defer<IEncoder<TypeRefModel<TypeKindModel>>>.L _output = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(CategoryModel model)
    => base.Encode(model)
      .AddEnum("resolution", model.Resolution, "_Resolution")
      .AddEncoded("output", model.Output, _output.I)
      .AddList("modifiers", model.Modifiers, _modifiers.I, flow: true);

  internal static new CategoryEncoder Factory(IEncoderRepository r) => new(r);
}

internal class DirectivesEncoder(
  IEncoderRepository encoders
) : AndTypeEncoder<DirectivesModel, DirectiveModel>("directive", encoders)

{
  internal static DirectivesEncoder Factory(IEncoderRepository r) => new(r);
}

internal class DirectiveEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<DirectiveModel>
{
  private readonly Defer<IEncoder<InputParamModel>>.L _parameter = encoders.EncoderFor<InputParamModel>();

  internal override Structured Encode(DirectiveModel model)
    => base.Encode(model)
      .AddSet("locations", model.Locations, "_Location")
      .AddEncoded("parameter", model.Parameter, _parameter.I)
      .Add("repeatable", model.Repeatable.Encode());

  internal static new DirectiveEncoder Factory(IEncoderRepository r) => new(r);
}

internal class SettingEncoder(
  IEncoderRepository encoders
) : NamedEncoder<SettingModel>
{
  private readonly Defer<IEncoder<ConstantModel>>.L _constant = encoders.EncoderFor<ConstantModel>();

  internal override Structured Encode(SettingModel model)
    => base.Encode(model)
      .AddEncoded("value", model.Value, _constant.I);

  internal static new SettingEncoder Factory(IEncoderRepository r) => new(r);
}
