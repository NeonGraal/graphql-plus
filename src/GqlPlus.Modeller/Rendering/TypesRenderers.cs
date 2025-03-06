using System.Diagnostics.CodeAnalysis;

using GqlPlus.Resolving;

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
  where TParent : ModelBase
{
  internal override Structured Render(TModel model)
    => base.Render(model)
      .AddRendered("parent", model.Parent, parent);

  internal virtual bool GetParentModel<TInput, TResult>(TInput input, IResolveContext context, [NotNullWhen(true)] out TResult? result)
    where TInput : ChildTypeModel<TParent>
    where TResult : IModelBase
  {
    if (input.ParentModel is null) {
      input.ParentModel = result = context.TryGetType(input.Name, ParentName(input.Parent), out TResult? parentModel)
        ? parentModel : default;
    } else {
      result = (TResult?)input.ParentModel;
    }

    return result is not null;
  }

  internal void ForParent<TInput, TResult>(TInput input, IResolveContext context, Action<TResult> action)
    where TInput : ChildTypeModel<TParent>
    where TResult : IChildTypeModel
  {
    if (GetParentModel(input, context, out TResult? parentModel)) {
      if (parentModel is ChildTypeModel<TParent> childModel) {
        ForParent(childModel, context, action);
      }

      action(parentModel);
    }
  }

  protected abstract string? ParentName(TParent? parent);
}

internal record class ParentTypeRenderers<TItem, TAll>(
  IRenderer<TypeRefModel<SimpleKindModel>> Parent,
  IRenderer<TItem> Item,
  IRenderer<TAll> All
  ) where TItem : ModelBase
    where TAll : ModelBase;

internal abstract class ParentTypeRenderer<TModel, TItem, TAll>(
  ParentTypeRenderers<TItem, TAll> renderers
) : ChildTypeRenderer<TModel, TypeRefModel<SimpleKindModel>>(renderers.Parent)
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : ModelBase
  where TAll : ModelBase
{
  internal override Structured Render(TModel model)
    => base.Render(model)
        .AddList("items", model.Items, renderers.Item)
        .AddList("allItems", model.AllItems, renderers.All);

  protected override string? ParentName(TypeRefModel<SimpleKindModel>? parent)
    => parent?.Name;

  protected abstract Func<TItem, TAll> NewItem(string parent);
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
  : NamedRenderer<TModel>
  where TModel : TypeRefModel<TKind>
  where TKind : struct
{
  private static readonly string s_typeKindTag = typeof(TKind).TypeTag();

  internal override Structured Render(TModel model)
    => base.Render(model)
      .Add("typeKind", new(model.TypeKind.ToString(), s_typeKindTag));
}

internal class SpecialTypeRenderer
  : BaseTypeRenderer<SpecialTypeModel>
{ }
