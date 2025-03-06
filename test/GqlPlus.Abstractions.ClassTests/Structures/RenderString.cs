
namespace GqlPlus.Structures;

internal sealed class RenderString
  : IRenderer<string>
{
  public Structured Render(string model)
    => new(model);
}
