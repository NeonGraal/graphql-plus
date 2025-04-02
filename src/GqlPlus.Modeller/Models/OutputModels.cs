namespace GqlPlus.Models;

public record class TypeOutputModel(
  string Name,
  string Description
) : TypeObjectModel<OutputBaseModel, OutputFieldModel, OutputAlternateModel>(TypeKindModel.Output, Name, Description)
{ }

public record class OutputArgModel(
  string Name,
  string Description
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name, Description), IObjArgModel
{
  internal string? Output => Name;
  public bool IsTypeParam { get; set; }
  internal DualArgModel? Dual { get; init; }

  internal string? EnumLabel { get; set; }
}

public record class OutputBaseModel(
  string Output,
  string Description
) : ObjBaseModel<OutputArgModel>(Description)
{
  internal DualBaseModel? Dual { get; init; }
}

public record class OutputFieldModel(
  string Name,
  OutputBaseModel? Type,
  string Description
) : ObjFieldModel<OutputBaseModel>(Name, Type, Description)
{
  internal InputParamModel[] Params { get; set; } = [];
  internal OutputEnumModel? Enum { get; set; }
}

public record class OutputAlternateModel(
  string Output,
  string Description
) : ObjAlternateModel<OutputArgModel>(Description)
{
  internal DualAlternateModel? Dual { get; init; }
}

public record class OutputEnumModel(
  string Field,
  string Type,
  string EnumLabel,
  string Description
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Type, Description)
{ }
