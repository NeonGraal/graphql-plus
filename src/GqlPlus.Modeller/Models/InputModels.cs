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
  , IInputModel
{
  internal DualArgModel? Dual { get; init; }
}

public record class InputBaseModel(
  string Input,
  string Description
) : ObjBaseModel<InputArgModel>(Description)
  , IInputModel
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
  InputBaseModel Type
) : ObjAlternateModel<InputBaseModel>(Type)
{
  internal DualAlternateModel? Dual { get; init; }
}

public record class InputParamModel(
  string Input,
  string Description
) : InputBaseModel(Input, Description)
  , IInputModel
{
  internal ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }
}

public interface IInputModel
{
  string Input { get; }
  bool IsTypeParam { get; }
}
