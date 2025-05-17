namespace GqlPlus.Rendering.Simple;

public class UnionMemberRendererTests
  : RendererClassTestBase<UnionMemberModel>
{
  protected override IRenderer<UnionMemberModel> Renderer => new UnionMemberRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string ofUnion, string contents)
    => RenderAndCheck(new(name, ofUnion, contents), [
      "!_UnionMember",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "union: " + ofUnion
      ]);
}
