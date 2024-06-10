namespace GqlPlus.Models;

public record class ModelBase
  : IRendering
{
  private string? _tag;

  internal virtual string Tag => _tag ??= GetType().TypeTag();

#pragma warning disable CA1033 // Interface methods should be callable by child types
  RenderStructure IRendering.Render(IRenderContext context)
    => throw new NotImplementedException();
}
