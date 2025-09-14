namespace GqlPlus.Models;

public record class TypeOutputModel(
  string Name,
  string Description
) : TypeObjectModel<OutputBaseModel, OutputFieldModel, OutputAlternateModel>(TypeKindModel.Output, Name, Description)
{ }

public record class OutputBaseModel(
  string Name,
  string Description
) : ObjBaseModel(Name, Description)
{
  public DualBaseModel? Dual { get; init; }
}

public record class OutputFieldModel(
  string Name,
  OutputBaseModel? Type,
  string Description
) : ObjFieldModel<OutputBaseModel>(Name, Type, Description)
{
  public InputParamModel[] Params { get; set; } = [];
  public OutputEnumModel? Enum { get; set; }
}

public record class OutputAlternateModel(
  OutputBaseModel Type
) : ObjAlternateModel<OutputBaseModel>(Type)
{
  public DualAlternateModel? Dual { get; init; }
}

public record class OutputEnumModel(
  string Field,
  string Type,
  string EnumLabel,
  string Description
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Type, Description)
{ }
