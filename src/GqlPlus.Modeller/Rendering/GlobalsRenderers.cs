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

  internal override RenderStructure Render(TModel model, IRenderContext context)
    => model.Type is null
      ? model.And is null
        ? new("")
        : and.And.Render(model.And, context)
      : model.And is null
        ? and.Type.Render(model.Type, context)
        : base.Render(model, context)
          .Add(_field, model.And, and.And)
          .Add("type", model.Type, and.Type);
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
  internal override RenderStructure Render(CategoryModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("resolution", model.Resolution, "_Resolution")
      .Add("output", model.Output, output)
      .Add("modifiers", model.Modifiers, modifiers, flow: true);
}

internal class DirectivesRenderer(
  AndBaseTypeRenderers<DirectiveModel> and
) : AndTypeRenderer<DirectivesModel, DirectiveModel>("directive", and)
{ }

internal class DirectiveRenderer(
  IRenderer<InputParameterModel> parameter
) : AliasedRenderer<DirectiveModel>
{
  internal override RenderStructure Render(DirectiveModel model, IRenderContext context)
    => base.Render(model, context)
      .AddSet("locations", model.Locations, "_Location")
      .Add("parameters", model.Parameters, parameter)
      .Add("repeatable", model.Repeatable);
}

internal class SettingRenderer(
  IRenderer<ConstantModel> constant
) : DescribedRenderer<SettingModel>
{
  internal override RenderStructure Render(SettingModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("value", model.Value, constant);
}
