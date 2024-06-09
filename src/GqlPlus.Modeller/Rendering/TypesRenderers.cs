using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Rendering;

internal class BaseTypeRenderer<TModel>
  : AliasedRenderer<TModel>
  , ITypeRenderer
  where TModel : BaseTypeModel
{
  public bool ForType(BaseTypeModel model)
    => model is TModel;

  public RenderStructure TypeRender(BaseTypeModel model, IRenderContext context)
    => Render((TModel)model, context);

  internal override RenderStructure Render(TModel model, IRenderContext context)
    => base.Render(model, context)
    .Add("typeKind", model.TypeKind.RenderEnum());
}

internal abstract class ChildTypeRenderer<TModel, TParent>
  : BaseTypeRenderer<TModel>
  where TModel : ChildTypeModel<TParent>
  where TParent : ModelBase
{
  internal override RenderStructure Render(TModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("parent", model.Parent?.Render(context));

  internal virtual bool GetParentModel<TInput, TResult>(TInput input, IRenderContext context, [NotNullWhen(true)] out TResult? result)
    where TInput : ChildTypeModel<TParent>
    where TResult : IRendering
  {
    if (input._parentModel is null) {
      input._parentModel = result = context.TryGetType(input.Name, ParentName(input.Parent), out TResult? parentModel)
        ? parentModel : default;
    } else {
      result = (TResult?)input._parentModel;
    }

    return result is not null;
  }

  internal void ForParent<TInput, TResult>(TInput input, IRenderContext context, Action<TResult> action)
    where TInput : ChildTypeModel<TParent>
    where TResult : ChildTypeModel<TParent>
  {
    if (GetParentModel(input, context, out TResult? parentModel)) {
      ForParent(parentModel, context, action);
      action(parentModel);
    }
  }

  protected abstract string? ParentName(TParent? parent);
}

internal abstract class ParentTypeRenderer<TModel, TItem, TAll>(
  IRenderer<TItem> item,
  IRenderer<TAll> all
) : ChildTypeRenderer<TModel, TypeRefModel<SimpleKindModel>>
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : ModelBase
  where TAll : ModelBase
{
  internal override RenderStructure Render(TModel model, IRenderContext context)
  {
    List<TAll> allItems = [];
    void AddMembers(ParentTypeModel<TItem, TAll> model)
      => allItems.AddRange(model.Items.Select(NewItem(model.Name)));

    ForParent<ParentTypeModel<TItem, TAll>, ParentTypeModel<TItem, TAll>>(model, context, AddMembers);
    AddMembers(model);

    return base.Render(model, context)
        .Add("items", model.Items.Render(item, context))
        .Add("allItems", allItems.Render(all, context));
  }

  protected override string? ParentName(TypeRefModel<SimpleKindModel>? parent)
    => parent?.Name;

  protected abstract Func<TItem, TAll> NewItem(string parent);
}

internal class AllTypesRenderer(
  IEnumerable<ITypeRenderer> types
) : IRenderer<BaseTypeModel>
{
  RenderStructure IRenderer<BaseTypeModel>.Render(BaseTypeModel model, IRenderContext context)
    // Todo: Should be Single instead of SingleOrDefault.
    => types
    .SingleOrDefault(t => t.ForType(model))
    ?.TypeRender(model, context)
    ?? model.Render(context);
}

internal interface ITypeRenderer
{
  bool ForType(BaseTypeModel model);
  RenderStructure TypeRender(BaseTypeModel model, IRenderContext context);
}
