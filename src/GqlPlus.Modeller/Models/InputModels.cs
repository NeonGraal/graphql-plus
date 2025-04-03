namespace GqlPlus.Models;

public record class TypeInputModel(
  string Name,
  string Description
) : TypeObjectModel<InputBaseModel, InputFieldModel, InputAlternateModel>(TypeKindModel.Input, Name, Description)
{ }

public record class InputArgModel(
  string Input,
  string Description
) : ObjArgModel(Description)
{
  internal DualArgModel? Dual { get; init; }
}

public record class InputBaseModel(
  string Input,
  string Description
) : ObjBaseModel<InputArgModel>(Description)
{
  internal DualBaseModel? Dual { get; init; }
}

public record class InputFieldModel(
  string Name,
  InputBaseModel? Type,
  string Description
) : ObjFieldModel<InputBaseModel>(Name, Type, Description)
{
  internal ConstantModel? Default { get; init; }
}

public record class InputAlternateModel(
  string Input,
  string Description
) : ObjAlternateModel<InputArgModel>(Description)
{
  internal DualAlternateModel? Dual { get; init; }
}

public record class InputParamModel(
  string Input,
  string Description
) : InputBaseModel(Input, Description)
{
  internal ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }
}
