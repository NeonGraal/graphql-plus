namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name,
  string Description
) : TypeObjectModel<DualBaseModel, DualFieldModel, DualAlternateModel>(TypeKindModel.Dual, Name, Description)
{ }

public record class DualArgModel(
  string Dual,
  string Description
) : ObjTypeArgModel(Description)
{ }

public record class DualBaseModel(
  string Dual,
  string Description
) : ObjBaseModel<DualArgModel>(Description)
{ }

public record class DualFieldModel(
  string Name,
  DualBaseModel? Type,
  string Description
) : ObjFieldModel<DualBaseModel>(Name, Type, Description)
{ }

public record class DualAlternateModel(
  string Dual,
  string Description
) : ObjAlternateModel<DualArgModel>(Description)
{ }
