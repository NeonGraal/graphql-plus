namespace GqlPlus.Rendering;

public interface IRenderer<TModel>
  where TModel : IModelBase
{
  RenderStructure Render(TModel model);
}
