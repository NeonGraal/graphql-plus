namespace GqlPlus.Structures;

public interface IRenderer<TModel>
{
  Structured Render(TModel model);
}
