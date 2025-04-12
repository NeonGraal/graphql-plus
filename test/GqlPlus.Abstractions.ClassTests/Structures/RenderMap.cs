
namespace GqlPlus.Structures;

internal sealed class RenderMap
  : IRenderer<Map<string>>
{
  public Structured Render(Map<string> model)
    => model.Render(s => new(s));
}
