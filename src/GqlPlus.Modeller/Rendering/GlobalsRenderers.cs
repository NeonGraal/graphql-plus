namespace GqlPlus.Rendering;

internal record class AndBaseTypeRenderers<TAnd>(
  IRenderer<TAnd> And,
  IRenderer<BaseTypeModel> Type
) where TAnd : ModelBase;

internal class AndTypeRenderer<TModel, TAnd>(
  string field,
  AndBaseTypeRenderers<TAnd> and
) : BaseRenderer<TModel>
  where TModel : AndTypeModel<TAnd>
  where TAnd : ModelBase
{
  private readonly string _field = field;

  internal override Structured Render(TModel model)
    => model.Type is null
      ? model.And is null
        ? new("")
        : and.And.Render(model.And)
      : model.And is null
        ? and.Type.Render(model.Type)
        : base.Render(model)
          .AddRendered(_field, model.And, and.And)
          .AddRendered("type", model.Type, and.Type);
}

internal class CategoriesRenderer(
  AndBaseTypeRenderers<CategoryModel> and
) : AndTypeRenderer<CategoriesModel, CategoryModel>("category", and)
{ }

internal class CategoryRenderer(
  IRenderer<ModifierModel> modifiers,
  IRenderer<TypeRefModel<TypeKindModel>> output
) : AliasedRenderer<CategoryModel>
{
  internal override Structured Render(CategoryModel model)
    => base.Render(model)
      .AddEnum("resolution", model.Resolution, "_Resolution")
      .AddRendered("output", model.Output, output)
      .AddList("modifiers", model.Modifiers, modifiers, flow: true);
}

internal class DirectivesRenderer(
  AndBaseTypeRenderers<DirectiveModel> and
) : AndTypeRenderer<DirectivesModel, DirectiveModel>("directive", and)
{ }

internal class DirectiveRenderer(
  IRenderer<InputParamModel> parameter
) : AliasedRenderer<DirectiveModel>
{
  internal override Structured Render(DirectiveModel model)
    => base.Render(model)
      .AddSet("locations", model.Locations, "_Location")
      .AddList("parameters", model.Params, parameter)
      .Add("repeatable", model.Repeatable);
}

internal class SettingRenderer(
  IRenderer<ConstantModel> constant
) : DescribedRenderer<SettingModel>
{
  internal override Structured Render(SettingModel model)
    => base.Render(model)
      .AddRendered("value", model.Value, constant);
}
