namespace GqlPlus.Models;

public record class TypeOutputModel(
  string Name,
  string Description
) : TypeObjectModel<OutputFieldModel>(TypeKindModel.Output, Name, Description)
{ }

public record class OutputFieldModel(
  string Name,
  ObjBaseModel? Type,
  string Description
) : ObjFieldModel(Name, Type, Description)
{
  public InputParamModel[] Params { get; set; } = [];
  public OutputEnumModel? Enum { get; set; }
}

public record class OutputEnumModel(
  string Field,
  string Type,
  string EnumLabel,
  string Description
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Type, Description)
{ }
