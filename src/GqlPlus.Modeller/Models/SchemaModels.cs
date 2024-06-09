namespace GqlPlus.Models;

public record class SchemaModel(
  string Name
) : AliasedModel(Name)
{
  public SchemaModel(
    string name,
    IEnumerable<CategoryModel> categories,
    IEnumerable<DirectiveModel> directives,
    IEnumerable<SettingModel> settings,
    IEnumerable<BaseTypeModel> types,
    ITokenMessages errors)
    : this(name)
  {
    Categories = categories.ToMap(c => c.Name);
    Directives = directives.ToMap(d => d.Name);
    Types = types.ToMap(t => t.Name);
    Settings = settings.ToMap(s => s.Name);
    Errors = new TokenMessages();
    if (errors is not null) {
      Errors.Add(errors);
    }
  }

  internal IMap<CategoryModel> Categories { get; } = new Map<CategoryModel>();
  internal IMap<DirectiveModel> Directives { get; } = new Map<DirectiveModel>();
  internal IMap<BaseTypeModel> Types { get; } = new Map<BaseTypeModel>();
  internal IMap<SettingModel> Settings { get; init; } = new Map<SettingModel>();
  public ITokenMessages Errors { get; } = new TokenMessages();

#pragma warning disable IDE0060 // Remove unused parameter
  public IMap<CategoriesModel> GetCategories(CategoryFilterParameter? filter)
    => Categories.ToMap(c => c.Key,
      c => new CategoriesModel() {
        And = c.Value,
        Type = Types.TryGetValue(c.Key, out BaseTypeModel? type) ? type : null,
      });

  public IMap<DirectivesModel> GetDirectives(FilterParameter? filter)
    => Directives.ToMap(d => d.Key,
      d => new DirectivesModel() {
        And = d.Value,
        Type = Types.TryGetValue(d.Key, out BaseTypeModel? type) ? type : null,
      });

  public IMap<BaseTypeModel> GetTypes(TypeFilterParameter? filter) => Types;
  public IMap<SettingModel> GetSettings(FilterParameter? filter) => Settings;
#pragma warning restore IDE0060 // Remove unused parameter

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("categories", GetCategories(default).Render(context, keyTag: "_Identifier", "_Categories"))
      .Add("directives", GetDirectives(default).Render(context, keyTag: "_Identifier", "_Directives"))
      .Add("types", GetTypes(default).Render(context, keyTag: "_Identifier", "_Type"))
      .Add("settings", GetSettings(default).Render(context, keyTag: "_Identifier", "_Setting"))
      .Add("_errors", Errors.Render());
}

public record class FilterParameter(
  string[] Names
)
{
  public bool MatchAliases { get; set; } = true;
  public string[] Aliases { get; set; } = [];
  public bool ReturnReferencedTypes { get; set; }
  public bool ReturnByAlias { get; set; }
}

public record class CategoryFilterParameter(
  string[] Names
) : FilterParameter(Names)
{
  public CategoryOption[] Resolutions { get; set; } = [];
}

public record class TypeFilterParameter(
  string[] Names
) : FilterParameter(Names)
{
  public TypeKindModel[] Kinds { get; set; } = [];
}
