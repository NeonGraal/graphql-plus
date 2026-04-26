namespace GqlPlus.Models;

public record class TypeInputModel(
  string Name,
  string Description
) : TypeObjectModel<InputFieldModel>(TypeKindModel.Input, Name, Description)
{ }

public record class InputFieldModel(
  string Name,
  ObjBaseModel? Type,
  string Description
) : ObjFieldModel(Name, Type, Description)
{
  public ConstantModel? Default { get; init; }
}

public record class InputParamModel(
  string Name,
  string Description
) : ObjBaseModel(Name, Description)
{
  public ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }
}
