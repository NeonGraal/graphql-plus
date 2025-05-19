﻿namespace GqlPlus.Models;

public record class SchemaModel(
  string Name,
  string Description
) : AliasedModel(Name, Description)
{
  public SchemaModel(
    string name,
    IEnumerable<CategoryModel> categories,
    IEnumerable<DirectiveModel> directives,
    IEnumerable<SettingModel> settings,
    IEnumerable<BaseTypeModel> types,
    ITokenMessages? errors)
    : this(name, "")
  {
    Categories = categories.ToMap(c => c.Name);
    Directives = directives.ToMap(d => d.Name);
    Types = types.ToMap(t => t.Name);
    Settings = settings.ToMap(s => s.Name);
    Errors = TokenMessages.New;
    if (errors is not null) {
      Errors.Add(errors);
    }
  }

  internal IMap<CategoryModel> Categories { get; } = new Map<CategoryModel>();
  internal IMap<DirectiveModel> Directives { get; } = new Map<DirectiveModel>();
  internal IMap<BaseTypeModel> Types { get; init; } = new Map<BaseTypeModel>();
  internal IMap<SettingModel> Settings { get; init; } = new Map<SettingModel>();
  public ITokenMessages Errors { get; } = TokenMessages.New;

#pragma warning disable IDE0060 // Remove unused parameter
  public IMap<CategoriesModel> GetCategories(CategoryFilterParam? filter)
    => Categories.ToMap(c => c.Key,
      c => new CategoriesModel() {
        And = c.Value,
        Type = Types.TryGetValue(c.Key, out BaseTypeModel? type) ? type : null,
      });

  public IMap<DirectivesModel> GetDirectives(FilterParam? filter)
    => Directives.ToMap(d => d.Key,
      d => new DirectivesModel() {
        And = d.Value,
        Type = Types.TryGetValue(d.Key, out BaseTypeModel? type) ? type : null,
      });

  public IMap<BaseTypeModel> GetTypes(TypeFilterParam? filter) => Types;
  public IMap<SettingModel> GetSettings(FilterParam? filter) => Settings;
#pragma warning restore IDE0060
}

public record class FilterParam(
  string[] Names
)
{
  public bool MatchAliases { get; set; } = true;
  public string[] Aliases { get; set; } = [];
  public bool ReturnReferencedTypes { get; set; }
  public bool ReturnByAlias { get; set; }
}

public record class CategoryFilterParam(
  string[] Names
) : FilterParam(Names)
{
  public CategoryOption[] Resolutions { get; set; } = [];
}

public record class TypeFilterParam(
  string[] Names
) : FilterParam(Names)
{
  public TypeKindModel[] Kinds { get; set; } = [];
}

public record class AliasedModel(
  string Name,
  string Description
) : NamedModel(Name, Description)
  , IAliasedModel
{
  public string[] Aliases { get; set; } = [];
}

public interface IAliasedModel
  : INamedModel
{
  string[] Aliases { get; }
}

public record class DescribedModel(
  string Description
) : ModelBase
  , IDescribedModel
{ }

public interface IDescribedModel
  : IModelBase
{
  string? Description { get; }
}

public record class NamedModel(
  string Name,
  string Description
) : DescribedModel(Description)
  , INamedModel
{ }

public interface INamedModel
  : IDescribedModel
{
  string Name { get; }
}
