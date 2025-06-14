namespace GqlPlus.Rendering.Simple;

public class TypeEnumRendererTests
  : ParentTypeRendererClassTestBase<TypeEnumModel, AliasedModel, EnumLabelModel, string>
{
  public TypeEnumRendererTests()
    => Renderer = new TypeEnumRenderer(Renderers);

  protected override IRenderer<TypeEnumModel> Renderer { get; }
  protected override SimpleKindModel Kind => SimpleKindModel.Enum;

  protected override EnumLabelModel NewAll(string item, string name) => new(item, name, "");
  protected override AliasedModel NewItem(string item) => new(item, "");
  protected override TypeEnumModel NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent)
    => new(name, contents) { Parent = parent };
}
