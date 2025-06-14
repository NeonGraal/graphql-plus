using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Rendering;

public abstract class RendererClassTestBase<TModel>
  : SubstituteBase
  where TModel : IModelBase
{
  protected abstract IRenderer<TModel> Renderer { get; }

  internal static IRenderer<TM> RFor<TM>()
    where TM : IModelBase
    => A.Of<IRenderer<TM>>();
  public void RenderReturnsMap<T>([NotNull] IRenderer<T> renderer, string tag, object? value)
    where T : IModelBase
  {
    Map<Structured> returns = new() { ["value"] = StructureValue.Str($"{value}", tag) };
    renderer.Render(default!).ReturnsForAnyArgs(returns.Render());
  }
  public void RenderReturns<T>([NotNull] IRenderer<T> renderer, T model, Structured returns)
    where T : IModelBase
    => renderer.Render(model).ReturnsForAnyArgs(returns);

  internal void RenderAndCheck(TModel model, string[] expected)
    => Renderer.Render(model)
      .ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe(expected);
}
