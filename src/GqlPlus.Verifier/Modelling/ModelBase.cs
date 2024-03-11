using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract record class ModelBase
  : IRendering
{
  private string? _tag;

  protected virtual string Tag => _tag ??= GetType().TypeTag();

  internal virtual RenderStructure Render(IRenderContext context)
    => RenderStructure.New(Tag);

  [SuppressMessage("Design", "CA1033:Interface methods should be callable by child types")]
  RenderStructure IRendering.Render(IRenderContext context) => Render(context);
}
