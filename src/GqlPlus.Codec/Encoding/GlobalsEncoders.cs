namespace GqlPlus.Encoding;

internal class AndTypeEncoder<TModel, TAnd>(
  string field,
  IEncoderRepository encoders
) : BaseEncoder<TModel>
  where TModel : AndTypeModel<TAnd>
  where TAnd : ModelBase
{
  private readonly string _field = field;
  private readonly IEncoder<TAnd> _and = encoders.EncoderFor<TAnd>();
  private readonly IEncoder<BaseTypeModel> _type = encoders.EncoderFor<BaseTypeModel>();

  internal override Structured Encode(TModel model)
    => model.Type is null
      ? model.And is null
        ? new("")
        : _and.Encode(model.And)
      : model.And is null
        ? _type.Encode(model.Type)
        : base.Encode(model)
          .AddEncoded(_field, model.And, _and)
          .AddEncoded("type", model.Type, _type);
}

internal class CategoriesEncoder(
  IEncoderRepository encoders
) : AndTypeEncoder<CategoriesModel, CategoryModel>("category", encoders)
{ }

internal class CategoryEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<CategoryModel>
{
  private readonly IEncoder<ModifierModel> _modifiers = encoders.EncoderFor<ModifierModel>();
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _output = encoders.EncoderFor<TypeRefModel<TypeKindModel>>();

  internal override Structured Encode(CategoryModel model)
    => base.Encode(model)
      .AddEnum("resolution", model.Resolution, "_Resolution")
      .AddEncoded("output", model.Output, _output)
      .AddList("modifiers", model.Modifiers, _modifiers, flow: true);
}

internal class DirectivesEncoder(
  IEncoderRepository encoders
) : AndTypeEncoder<DirectivesModel, DirectiveModel>("directive", encoders)
{ }

internal class DirectiveEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<DirectiveModel>
{
  private readonly IEncoder<InputParamModel> _parameter = encoders.EncoderFor<InputParamModel>();

  internal override Structured Encode(DirectiveModel model)
    => base.Encode(model)
      .AddSet("locations", model.Locations, "_Location")
      .AddEncoded("parameter", model.Parameter, _parameter)
      .Add("repeatable", model.Repeatable);
}

internal class SettingEncoder(
  IEncoderRepository encoders
) : NamedEncoder<SettingModel>
{
  private readonly IEncoder<ConstantModel> _constant = encoders.EncoderFor<ConstantModel>();

  internal override Structured Encode(SettingModel model)
    => base.Encode(model)
      .AddEncoded("value", model.Value, _constant);
}
