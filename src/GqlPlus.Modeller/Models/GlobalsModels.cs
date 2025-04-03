namespace GqlPlus.Models;

public record class AndTypeModel<TModel>
  : ModelBase
  where TModel : ModelBase
{
  public TModel? And { get; set; }

  public BaseTypeModel? Type { get; init; }
}

public record class CategoriesModel()
  : AndTypeModel<CategoryModel>
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
  : AndTypeModel<DirectiveModel>
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

public record class OperationsModel()
  : AndTypeModel<OperationModel>
{ }

public record class OperationModel(
  string Name,
  string Category,
  string Operation,
  string Description
) : AliasedModel(Name, Description)
{ }

public record class SettingModel(
  string Name,
  ConstantModel Value,
  string Description
) : NamedModel(Name, Description)
{ }
