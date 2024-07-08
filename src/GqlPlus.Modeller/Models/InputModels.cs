namespace GqlPlus.Models;

public record class TypeInputModel(
  string Name
) : TypeObjectModel<InputBaseModel, InputFieldModel, InputAlternateModel>(TypeKindModel.Input, Name)
{ }

public record class InputArgumentModel(
  string Input
) : ObjArgumentModel
{
  internal DualArgumentModel? Dual { get; init; }
}

public record class InputBaseModel(
  string Input
) : ObjBaseModel<InputArgumentModel>
{
  internal DualBaseModel? Dual { get; init; }
}

public record class InputFieldModel(
  string Name,
  ObjDescribedModel<InputBaseModel> Type
) : ObjFieldModel<InputBaseModel>(Name, Type)
{
  internal ConstantModel? Default { get; init; }
}

public record class InputAlternateModel(
  ObjDescribedModel<InputBaseModel> Type
) : ObjAlternateModel<InputBaseModel>(Type)
{ }

public record class InputParameterModel(
  ObjDescribedModel<InputBaseModel> Type
) : ModelBase
{
  internal ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }
}
