namespace GqlPlus.Rendering;

public class SchemaRendererTests
  : RendererClassTestBase<SchemaModel>
{
  private readonly IRenderer<CategoriesModel> _categories;
  private readonly IRenderer<DirectivesModel> _directives;
  private readonly IRenderer<BaseTypeModel> _types;
  private readonly IRenderer<SettingModel> _settings;

  public SchemaRendererTests()
  {
    _categories = RFor<CategoriesModel>();
    _directives = RFor<DirectivesModel>();
    _types = RFor<BaseTypeModel>();
    _settings = RFor<SettingModel>();

    Renderer = new SchemaRenderer(_categories, _directives, _types, _settings);
  }

  protected override IRenderer<SchemaModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_Schema",
      "description: " + contents.Quoted("'"),
      "name: " + name
      ]);
}
