using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class SchemaModel(
  string Name
) : NamedModel(Name)
{
  internal DirectiveModel[] Directives { get; init; } = [];
  internal SettingModel[] Settings { get; init; } = [];

  public IMap<CategoriesModel> GetCategories(CategoryFilterParameter? filter) => new Map<CategoriesModel>();
  public IMap<DirectivesModel> GetDirectives(FilterParameter? filter)
    => Directives.ToMap(d => d.Name, d => new DirectivesModel() { Directive = d });
  public IMap<BaseTypeModel> GetTypes(TypeFilterParameter? filter) => new Map<BaseTypeModel>();
  public IMap<SettingModel> GetSettings(FilterParameter? filter)
    => Settings.ToMap(s => s.Name);

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("categories", GetCategories(default).Render(context, keyTag: "_Identifier"))
      .Add("directives", GetDirectives(default).Render(context, keyTag: "_Identifier", "_Directives"))
      .Add("types", GetTypes(default).Render(context, keyTag: "_Identifier"))
      .Add("settings", GetSettings(default).Render(context, keyTag: "_Identifier", "_Setting"));
}

public record class FilterParameter(
  string[] Names
)
{
  public bool IncludeReferencedTypes { get; set; }
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
  IModeller<DirectiveDeclAst, DirectiveModel> directive,
  IModeller<OptionSettingAst, SettingModel> setting
) : ModellerBase<SchemaAst, SchemaModel>
{
  internal override SchemaModel ToModel(SchemaAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Directives = DeclarationModels<DirectiveDeclAst, DirectiveModel>(ast, d => [directive.ToModel(d, typeKinds)]),
      Settings = DeclarationModels<OptionDeclAst, SettingModel>(ast, o => setting.ToModels(o.Settings, typeKinds)),
    };

  private TResult[] DeclarationModels<TAst, TResult>(SchemaAst ast, Func<TAst, IEnumerable<TResult>> many)
    => [.. ast.Declarations.OfType<TAst>().SelectMany(many)];
}
