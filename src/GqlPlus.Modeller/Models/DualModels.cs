namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name
) : TypeObjectModel<DualBaseModel, DualFieldModel, DualAlternateModel>(TypeKindModel.Dual, Name)
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
  ObjDescribedModel<DualBaseModel>? Type
) : ObjFieldModel<DualBaseModel>(Name, Type)
{ }

public record class DualAlternateModel(
  ObjDescribedModel<DualBaseModel> Type
) : ObjAlternateModel<DualBaseModel>(Type)
{ }
