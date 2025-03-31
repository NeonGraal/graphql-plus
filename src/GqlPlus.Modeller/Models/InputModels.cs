﻿namespace GqlPlus.Models;

public record class TypeInputModel(
  string Name,
  string Description
) : TypeObjectModel<InputBaseModel, InputFieldModel, InputAlternateModel>(TypeKindModel.Input, Name, Description)
{ }

public record class InputArgModel(
  string Input
) : ObjArgModel
{
  internal DualArgModel? Dual { get; init; }
}

public record class InputBaseModel(
  string Input
) : ObjBaseModel<InputArgModel>
{
  internal DualBaseModel? Dual { get; init; }
}

public record class InputFieldModel(
  string Name,
  ObjDescribedModel<InputBaseModel>? Type,
  string Description
) : ObjFieldModel<InputBaseModel>(Name, Type, Description)
{
  internal ConstantModel? Default { get; init; }
}

public record class InputAlternateModel(
  ObjDescribedModel<InputBaseModel> Type
) : ObjAlternateModel<InputBaseModel>(Type)
{ }

public record class InputParamModel(
  ObjDescribedModel<InputBaseModel> Type
) : ModelBase
{
  internal ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }
}
