namespace GqlPlus.Rendering;

public interface IRenderer<TModel>
{
  Structured Render(TModel model);
}
