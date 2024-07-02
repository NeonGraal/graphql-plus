namespace GqlPlus.Models;

public record class TypeOutputModel(
  string Name
) : TypeObjectModel<OutputBaseModel, OutputFieldModel, OutputAlternateModel>(TypeKindModel.Output, Name)
{
  protected override string? ParentName(ObjDescribedModel<OutputBaseModel>? parent)
    => parent?.Base.Output;
}

public record class OutputArgumentModel(
  string Name
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name), IObjArgumentModel
{
  internal string? Output => Name;
  public bool IsTypeParameter { get; set; }
  internal DualArgumentModel? Dual { get; init; }

  internal string? EnumMember { get; set; }
}

public record class OutputBaseModel(
  string Output
) : ObjBaseModel<OutputArgumentModel>
{
  internal DualBaseModel? Dual { get; init; }
}

public record class OutputFieldModel(
  string Name,
  ObjDescribedModel<OutputBaseModel>? Type
) : ObjFieldModel<OutputBaseModel>(Name, Type)
{
  internal InputParameterModel[] Parameters { get; set; } = [];
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
