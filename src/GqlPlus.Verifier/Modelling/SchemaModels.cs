using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Rendering;
using GqlPlus.Token;

namespace GqlPlus.Modelling;

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

  public IMap<CategoriesModel> GetCategories(CategoryFilterParameter? filter)
    => Categories.ToMap(c => c.Key,
      c => new CategoriesModel() {
        Category = c.Value,
        Type = Types.TryGetValue(c.Key, out var type) ? type : null,
      });

  public IMap<DirectivesModel> GetDirectives(FilterParameter? filter)
    => Directives.ToMap(d => d.Key,
      d => new DirectivesModel() {
        Directive = d.Value,
        Type = Types.TryGetValue(d.Key, out var type) ? type : null,
      });

  public IMap<BaseTypeModel> GetTypes(TypeFilterParameter? filter) => Types;
  public IMap<SettingModel> GetSettings(FilterParameter? filter) => Settings;

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

public record class AliasedModel(
  string Name
) : NamedModel(new NamedModel(Name))
{
  public string? Description { get; set; }
  public string[] Aliases { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("aliases", Aliases.Render())
      .Add("description", RenderValue.Str(Description));
}

public record class DescribedModel(
  string Name
) : NamedModel(Name)
{
  public string? Description { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("description", RenderValue.Str(Description));
}

public record class BaseDescribedModel<TBase>(
  TBase Base
) : ModelBase
  where TBase : IRendering
{
  public string? Description { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => string.IsNullOrEmpty(Description)
      ? Base.Render(context)
      : base.Render(context)
        .Add("base", Base.Render(context))
        .Add("description", RenderValue.Str(Description));
}

public record class NamedModel(
  string Name
) : ModelBase
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("name", Name);
}

internal class SchemaModeller(
  IModeller<CategoryDeclAst, CategoryModel> category,
  IModeller<DirectiveDeclAst, DirectiveModel> directive,
  IModeller<OptionSettingAst, SettingModel> setting,
  ITypesModeller type
) : ModellerBase<SchemaAst, SchemaModel>
{
  protected override SchemaModel ToModel(SchemaAst ast, IMap<TypeKindModel> typeKinds)
  {
    AstType[] types = [.. ast.Declarations.OfType<AstType>()];
    ITokenMessages errors = ast.Errors;
    if (typeKinds is TypesCollection collection) {
      errors = collection.Errors;
      errors.Clear();
      errors.Add(ast.Errors);
    }

    type.AddTypeKinds(types, typeKinds);

    OptionDeclAst[] options = [.. ast.Declarations.OfType<OptionDeclAst>()];
    string name = options.LastOrDefault(options => !string.IsNullOrWhiteSpace(options.Name))?.Name ?? "";
    IEnumerable<string> aliases = options.SelectMany(a => a.Aliases);
    IEnumerable<SettingModel> settings = options.SelectMany(o => setting.ToModels(o.Settings, typeKinds));

    return new(name,
        DeclarationModel(ast, category, typeKinds),
        DeclarationModel(ast, directive, typeKinds),
        settings,
        types.Select(t => type.ToModel(t, typeKinds)),
        errors
        ) { Aliases = [.. aliases] };
  }

  private IEnumerable<TResult> DeclarationModel<TAst, TResult>(SchemaAst ast, IModeller<TAst, TResult> modeller, IMap<TypeKindModel> typeKinds)
    where TAst : AstBase
    => ast.Declarations.OfType<TAst>().Select(m => modeller.ToModel(m, typeKinds));
}
