﻿namespace GqlPlus.Models;

public record class AndTypeModel<TModel>
  : ModelBase
  where TModel : ModelBase
{
  private readonly string _field;

  public AndTypeModel(string field)
    => _field = field;

  public TModel? And { get; set; }

  public BaseTypeModel? Type { get; init; }
}

public record class CategoriesModel()
  : AndTypeModel<CategoryModel>("category")
{ }

public record class CategoryModel(
  string Name,
  TypeRefModel<TypeKindModel> Output,
  string Description
) : AliasedModel(Name, Description)
{
  public CategoryOption Resolution { get; set; } = CategoryOption.Parallel;
  public ModifierModel[] Modifiers { get; set; } = [];
}

public record class DirectivesModel()
  : AndTypeModel<DirectiveModel>("directive")
{ }

public record class DirectiveModel(
  string Name,
  string Description
) : AliasedModel(Name, Description)
{
  public InputParamModel[] Parameters { get; set; } = [];
  public bool Repeatable { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;
}

public record class SettingModel(
  string Name,
  ConstantModel Value,
  string Description
) : NamedModel(Name, Description)
{ }
