namespace GqlPlus.Rendering;

internal class BaseTypeRenderer<TModel>
  : AliasedRenderer<TModel>
  , ITypeRenderer
  where TModel : BaseTypeModel
{
  public bool ForType(BaseTypeModel model)
    => model is TModel;

  public Structured TypeRender(BaseTypeModel model)
    => Render((TModel)model);

  internal override Structured Render(TModel model)
    => base.Render(model)
    .Add("typeKind", model.TypeKind.RenderEnum());
}

internal abstract class ChildTypeRenderer<TModel, TParent>(
  IRenderer<TParent> parent
) : BaseTypeRenderer<TModel>
  where TModel : ChildTypeModel<TParent>
  where TParent : IModelBase
{
  internal override Structured Render(TModel model)
    => base.Render(model)
      .AddRendered("parent", model.Parent, parent);
}

internal record class ParentTypeRenderers<TItem, TAll>(
  IRenderer<TypeRefModel<SimpleKindModel>> Parent,
  IRenderer<TItem> Item,
  IRenderer<TAll> All
  ) where TItem : IModelBase
    where TAll : IModelBase;

internal abstract class ParentTypeRenderer<TModel, TItem, TAll>(
  ParentTypeRenderers<TItem, TAll> renderers
) : ChildTypeRenderer<TModel, TypeRefModel<SimpleKindModel>>(renderers.Parent)
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  internal override Structured Render(TModel model)
    => base.Render(model)
        .AddList("items", model.Items, renderers.Item)
        .AddList("allItems", model.AllItems, renderers.All);
}

internal class AllTypesRenderer(
  IEnumerable<ITypeRenderer> types
) : IRenderer<BaseTypeModel>
{
  Structured IRenderer<BaseTypeModel>.Render(BaseTypeModel model)
    => types
    .SingleOrDefault(t => t.ForType(model))
    ?.TypeRender(model)
    ?? throw new InvalidOperationException("Unable to find Renderer for " + model.GetType().ExpandTypeName());
}

internal interface ITypeRenderer
{
  bool ForType(BaseTypeModel model);
  Structured TypeRender(BaseTypeModel model);
}

internal class TypeRefRenderer<TModel, TKind>
  : DescribedRenderer<TModel>
  where TModel : TypeRefModel<TKind>
  where TKind : struct
{
  private static readonly string s_typeKindTag = typeof(TKind).TypeTag();

  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("typeName", model.TypeName)
      .Add("typeKind", new(model.TypeKind.ToString(), s_typeKindTag));
}

internal class SpecialTypeRenderer
  : BaseTypeRenderer<SpecialTypeModel>
{ }
