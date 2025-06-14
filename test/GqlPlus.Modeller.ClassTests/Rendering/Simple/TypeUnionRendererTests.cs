namespace GqlPlus.Rendering.Simple;

public class TypeUnionRendererTests
  : ParentTypeRendererClassTestBase<TypeUnionModel, NamedModel, UnionMemberModel, string>
{
  public TypeUnionRendererTests()
    => Renderer = new TypeUnionRenderer(Renderers);

  protected override IRenderer<TypeUnionModel> Renderer { get; }
  protected override SimpleKindModel Kind => SimpleKindModel.Union;

  protected override UnionMemberModel NewAll(string item, string name) => new(item, name, "");
  protected override NamedModel NewItem(string item) => new(item, "");
  protected override TypeUnionModel NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent)
    => new(name, contents) { Parent = parent };
}
