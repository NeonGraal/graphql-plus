namespace GqlPlus.Encoding;

internal record class AndBaseTypeEncoders<TAnd>(
  IEncoder<TAnd> And,
  IEncoder<BaseTypeModel> Type
) where TAnd : ModelBase;

internal class AndTypeEncoder<TModel, TAnd>(
  string field,
  AndBaseTypeEncoders<TAnd> and
) : BaseEncoder<TModel>
  where TModel : AndTypeModel<TAnd>
  where TAnd : ModelBase
{
  private readonly string _field = field;

  internal override Structured Encode(TModel model)
    => model.Type is null
      ? model.And is null
        ? new("")
        : and.And.Encode(model.And)
      : model.And is null
        ? and.Type.Encode(model.Type)
        : base.Encode(model)
          .AddEncoded(_field, model.And, and.And)
          .AddEncoded("type", model.Type, and.Type);
}

internal class CategoriesEncoder(
  AndBaseTypeEncoders<CategoryModel> and
) : AndTypeEncoder<CategoriesModel, CategoryModel>("category", and)
{ }

internal class CategoryEncoder(
  IEncoder<ModifierModel> modifiers,
  IEncoder<TypeRefModel<TypeKindModel>> output
) : AliasedEncoder<CategoryModel>
{
  internal override Structured Encode(CategoryModel model)
    => base.Encode(model)
      .AddEnum("resolution", model.Resolution, "_Resolution")
      .AddEncoded("output", model.Output, output)
      .AddList("modifiers", model.Modifiers, modifiers, flow: true);
}

internal class DirectivesEncoder(
  AndBaseTypeEncoders<DirectiveModel> and
) : AndTypeEncoder<DirectivesModel, DirectiveModel>("directive", and)
{ }

internal class DirectiveEncoder(
  IEncoder<InputParamModel> parameter
) : AliasedEncoder<DirectiveModel>
{
  internal override Structured Encode(DirectiveModel model)
    => base.Encode(model)
      .AddSet("locations", model.Locations, "_Location")
      .AddList("parameters", model.Parameters, parameter)
      .Add("repeatable", model.Repeatable);
}

internal class OperationsEncoder(
  AndBaseTypeEncoders<OperationModel> and
) : AndTypeEncoder<OperationsModel, OperationModel>("operation", and)
{ }

internal class OperationEncoder
  : AliasedEncoder<OperationModel>
{
  internal override Structured Encode(OperationModel model)
    => base.Encode(model)
      .Add("category", model.Category)
      .Add("operation", model.Operation);
}

internal class SettingEncoder(
  IEncoder<ConstantModel> constant
) : NamedEncoder<SettingModel>
{
  internal override Structured Encode(SettingModel model)
    => base.Encode(model)
      .AddEncoded("value", model.Value, constant);
}
