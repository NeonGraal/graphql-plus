﻿namespace GqlPlus.Models;

public record class TypeInputModel(
  string Name,
  string Description
) : TypeObjectModel<InputBaseModel, InputFieldModel, InputAlternateModel>(TypeKindModel.Input, Name, Description)
{ }

public record class InputArgModel(
  string Input,
  string Description
) : ObjTypeArgModel(Description)
  , IInputModel
{
  public DualArgModel? Dual { get; init; }
}

public record class InputBaseModel(
  string Input,
  string Description
) : ObjBaseModel<InputArgModel>(Description)
  , IInputModel
{
  public DualBaseModel? Dual { get; init; }
}

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
{
  public DualAlternateModel? Dual { get; init; }
}

public record class InputParamModel(
  string Input,
  string Description
) : InputBaseModel(Input, Description)
  , IInputModel
{
  public ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }
}

public interface IInputModel
{
  string Input { get; }
  bool IsTypeParam { get; }
}
