namespace GqlPlus.Models;

public record class OperationsModel()
  : AndTypeModel<OperationModel>;

public record class OperationModel(
  string Name,
  string Category,
  string Description
) : AliasedModel(Name, Description)
{
  public IMap<OpVariableModel> Variables { get; init; } = new Map<OpVariableModel>();
  public OpDirectiveModel[] Directives { get; init; } = [];
  public IMap<OpFragmentModel> Fragments { get; init; } = new Map<OpFragmentModel>();
  public OpResultModel? Result { get; init; }
  public IMap<OpSelectionModel[]> Selections { get; init; } = new Map<OpSelectionModel[]>();
  public ModifierModel[] Modifiers { get; init; } = [];
}

public record class OpDirectivesModel(
  string Name,
  string Description
) : NamedModel(Name, Description)
{
  public OpDirectiveModel[] Directives { get; init; } = [];
}

public record class OpDirectiveModel(
  string Name,
  string Description
) : NamedModel(Name, Description)
{
  public OpArgumentModel? Argument { get; set; }
}

public record class OpArgumentModel
  : ModelBase;

public record class OpFragmentModel(
  string Name,
  TypeRefModel<TypeKindModel> Type,
  string Description
) : OpDirectivesModel(Name, Description);

public record class OpVariableModel(
  string Name,
  TypeRefModel<TypeKindModel>? Type,
  ConstantModel? DefaultValue,
  string Description
) : OpDirectivesModel(Name, Description);

public record class OpResultModel(
  TypeRefModel<TypeKindModel> Domain
) : ModelBase
{
  public OpArgumentModel? Argument { get; set; }
}

public abstract record class OpSelectionModel(
  string Description
) : DescribedModel(Description)
{
  public OpDirectiveModel[] Directives { get; init; } = [];
  public ModifierModel[] Modifiers { get; init; } = [];
}

public record class OpFieldSelectionModel(
  string Name,
  string Description
) : OpSelectionModel(Description)
{
  public string? Alias { get; init; }
  public OpArgumentModel? Argument { get; init; }
}

public record class OpInlineSelectionModel(
  TypeRefModel<TypeKindModel>? Type,
  string Description
) : OpSelectionModel(Description);

public record class OpSpreadSelectionModel(
  string Fragment,
  string Description
) : OpSelectionModel(Description);
