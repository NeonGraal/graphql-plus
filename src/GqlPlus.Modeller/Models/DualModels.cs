namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name,
  string Description
) : TypeObjectModel<DualBaseModel, DualFieldModel, DualAlternateModel>(TypeKindModel.Dual, Name, Description)
{ }

public record class DualArgModel(
  TypeKindModel Kind,
  string Name,
  string Description
) : ObjTypeArgModel(Kind, Name, Description)
{ }

public record class DualBaseModel(
  string Name,
  string Description
) : ObjBaseModel<DualArgModel>(Name, Description)
{ }

public record class DualFieldModel(
  string Name,
  DualBaseModel? Type,
  string Description
) : ObjFieldModel<DualBaseModel>(Name, Type, Description)
{ }

public record class DualAlternateModel(
  DualBaseModel Type
) : ObjAlternateModel<DualBaseModel>(Type)
{ }
