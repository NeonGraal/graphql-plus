using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Modelling;

public record class SchemaModel(
  string Name
) : NamedModel(Name), IRenderContext
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
    Errors = errors;
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
      .Add("_errors", new(Errors.Select(RenderError), "_Errors"))
      .Add("categories", GetCategories(default).Render(context, keyTag: "_Identifier", "_Categories"))
      .Add("directives", GetDirectives(default).Render(context, keyTag: "_Identifier", "_Directives"))
      .Add("types", GetTypes(default).Render(context, keyTag: "_Identifier", "_Type"))
      .Add("settings", GetSettings(default).Render(context, keyTag: "_Identifier", "_Setting"));

  private RenderStructure RenderError(TokenMessage error)
    => RenderStructure.New("_Error")
      .Add(error.Kind is TokenKind.Start or TokenKind.End, r => r,
        r => r.Add("_at", RenderAt(error)))
      .Add("_kind", error.Kind)
      .Add("_message", error.Message);

  private RenderStructure RenderAt(TokenAt at)
    => RenderStructure.New("_At", true)
      .Add("_col", at.Column)
      .Add("_line", at.Line);

  public bool TryGetType<TModel>(string? name, [NotNullWhen(true)] out TModel? model)
    where TModel : BaseTypeModel
  {
    if (name is not null) {
      if (Types.TryGetValue(name, out var type) && type is TModel modelType) {
        model = modelType;
        return true;
      }

      Errors.Add(new TokenMessage(TokenKind.End, 0, 0, "", $"Unable to get model for type '{name}'"));
    }

    model = null;
    return false;
  }
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
  IModeller<CategoryDeclAst, CategoryModel> category,
  IModeller<DirectiveDeclAst, DirectiveModel> directive,
  IModeller<OptionSettingAst, SettingModel> setting,
  ITypesModeller type
) : ModellerBase<SchemaAst, SchemaModel>
{
  internal override SchemaModel ToModel(SchemaAst ast, IMap<TypeKindModel> typeKinds)
  {
    AddBuiltIns(typeKinds);
    type.AddTypeKinds(ast.Declarations.OfType<AstType>(), typeKinds);
    AddBuiltInAliases(typeKinds);

    return new(ast.Name,
        DeclarationModel(ast, category, typeKinds),
        DeclarationModel(ast, directive, typeKinds),
        ast.Declarations.OfType<OptionDeclAst>().SelectMany(o => setting.ToModels(o.Settings, typeKinds)),
        DeclarationModel(ast, type, typeKinds),
        ast.Errors
        );
  }

  private static void AddBuiltIns(IMap<TypeKindModel> typeKinds)
  {
    foreach (var builtIn in BuiltIn.Basic) {
      typeKinds.Add(builtIn.Name, TypeKindModel.Basic);
    }

    foreach (var builtIn in BuiltIn.Internal) {
      typeKinds.Add(builtIn.Name, TypeKindModel.Internal);
    }
  }

  private static void AddBuiltInAliases(IMap<TypeKindModel> typeKinds)
  {
    foreach (var builtIn in BuiltIn.Basic.SelectMany(b => b.Aliases)) {
      typeKinds.TryAdd(builtIn, TypeKindModel.Basic);
    }

    foreach (var builtIn in BuiltIn.Internal.SelectMany(b => b.Aliases)) {
      typeKinds.TryAdd(builtIn, TypeKindModel.Internal);
    }
  }

  private IEnumerable<TResult> DeclarationModel<TAst, TResult>(SchemaAst ast, IModeller<TAst, TResult> modeller, IMap<TypeKindModel> typeKinds)
    where TAst : AstBase
    => ast.Declarations.OfType<TAst>().Select(m => modeller.ToModel(m, typeKinds));
}
