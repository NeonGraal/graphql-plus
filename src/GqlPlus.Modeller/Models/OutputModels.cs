namespace GqlPlus.Models;

public record class TypeOutputModel(
  string Name
) : TypeObjectModel<OutputBaseModel, OutputFieldModel, OutputAlternateModel>(TypeKindModel.Output, Name)
{ }

public record class OutputArgModel(
  string Name
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name), IObjArgModel
{
  internal string? Output => Name;
  public bool IsTypeParam { get; set; }
  internal DualArgModel? Dual { get; init; }

  internal string? EnumMember { get; set; }
}

public record class OutputBaseModel(
  string Output
) : ObjBaseModel<OutputArgModel>
{
  internal DualBaseModel? Dual { get; init; }
}

public record class OutputFieldModel(
  string Name,
  ObjDescribedModel<OutputBaseModel>? Type
) : ObjFieldModel<OutputBaseModel>(Name, Type)
{
  internal InputParamModel[] Params { get; set; } = [];
  internal OutputEnumModel? Enum { get; set; }
}

public record class OutputAlternateModel(
  ObjDescribedModel<OutputBaseModel> Type
) : ObjAlternateModel<OutputBaseModel>(Type)
{ }

public record class OutputEnumModel(
  string Field,
  string Type,
  string EnumMember
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Type)
{ }
