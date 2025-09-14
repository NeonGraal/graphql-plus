namespace GqlPlus.Models;

public record class TypeInputModel(
  string Name,
  string Description
) : TypeObjectModel<InputBaseModel, InputFieldModel, InputAlternateModel>(TypeKindModel.Input, Name, Description)
{ }

public record class InputBaseModel(
  string Name,
  string Description
) : ObjBaseModel(Name, Description)
{ }

public record class InputFieldModel(
  string Name,
  InputBaseModel? Type,
  string Description
) : ObjFieldModel<InputBaseModel>(Name, Type, Description)
{
  public ConstantModel? Default { get; init; }
}

public record class InputAlternateModel(
  InputBaseModel Type
) : ObjAlternateModel<InputBaseModel>(Type)
{ }

public record class InputParamModel(
  string Name,
  string Description
) : InputBaseModel(Name, Description)
{
  public ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }
}
