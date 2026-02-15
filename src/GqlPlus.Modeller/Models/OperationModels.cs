namespace GqlPlus.Models;

public record class OperationsModel()
  : AndTypeModel<OperationModel>
{ }

public record class OperationModel(
  string Name,
  string Category,
  OpResultModel Result,
  string Description
) : AliasedModel(Name, Description)
{
  public IMap<OpVariableModel> Variables { get; } = new Map<OpVariableModel>();
  public OpDirectiveModel[] Directives { get; set; } = [];
  public IMap<OpFragmentModel> Fragments { get; } = new Map<OpFragmentModel>();
  public IMap<OpSelectionModel[]> Selections { get; } = new Map<OpSelectionModel[]>();
}

public record class OpDirectivesModel(
  string Name,
  string Description
) : NamedModel(Name, Description)
{
  public OpDirectiveModel[] Directives { get; set; } = [];
}

public record class OpDirectiveModel(
  string Name,
  string Description
) : NamedModel(Name, Description)
{
  public OpArgumentModel? Argument { get; set; }
}

public record class OpArgumentModel
  : ModelBase
{ }

public record class OpFragmentModel(
  string Name,
  TypeRefModel<TypeKindModel> Type,
  string Description
) : OpDirectivesModel(Name, Description)
{ }

public record class OpVariableModel(
  string Name,
  TypeRefModel<TypeKindModel> Type,
  ConstantModel? DefaultValue,
  string Description
) : OpDirectivesModel(Name, Description)
{ }

public record class OpResultModel
  : ModelBase
{ }

public record class OpSelectionModel
  : ModelBase
{ }
