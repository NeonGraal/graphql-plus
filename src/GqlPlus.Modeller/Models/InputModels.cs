namespace GqlPlus.Models;

public record class TypeInputModel(
  string Name
) : TypeObjectModel<InputBaseModel, InputFieldModel>(TypeKindModel.Input, Name)
{
  protected override string? ParentName(ObjDescribedModel<InputBaseModel>? parent)
    => parent?.Base.Input;
}

public record class InputBaseModel(
  string Input
) : ObjBaseModel<InputBaseModel>
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

public record class InputParameterModel(
  ObjDescribedModel<InputBaseModel> Type
) : ModelBase
{
  internal ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }
}
