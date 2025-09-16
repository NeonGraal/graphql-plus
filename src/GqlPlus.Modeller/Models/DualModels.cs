namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name,
  string Description
) : TypeObjectModel<DualFieldModel>(TypeKindModel.Dual, Name, Description)
{ }

public record class DualFieldModel(
  string Name,
  ObjBaseModel? Type,
  string Description
) : ObjFieldModel(Name, Type, Description)
{ }
