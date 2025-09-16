namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name,
  string Description
) : TypeObjectModel<DualBaseModel, DualFieldModel, ObjAlternateModel>(TypeKindModel.Dual, Name, Description)
{ }

public record class DualBaseModel(
  string Name,
  string Description
) : ObjBaseModel(Name, Description)
{ }

public record class DualFieldModel(
  string Name,
  DualBaseModel? Type,
  string Description
) : ObjFieldModel<DualBaseModel>(Name, Type, Description)
{ }


