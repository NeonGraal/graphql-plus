namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name,
  string Description
) : TypeObjectModel<DualBaseModel, DualFieldModel, DualAlternateModel>(TypeKindModel.Dual, Name, Description)
{ }

public record class DualArgModel(
  string Dual
) : ObjArgModel
{ }

public record class DualBaseModel(
  string Dual
) : ObjBaseModel<DualArgModel>
{ }

public record class DualFieldModel(
  string Name,
  ObjDescribedModel<DualBaseModel>? Type,
  string Description
) : ObjFieldModel<DualBaseModel>(Name, Type, Description)
{ }

public record class DualAlternateModel(
  ObjDescribedModel<DualBaseModel> Type
) : ObjAlternateModel<DualBaseModel>(Type)
{ }
