namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name,
  string Description
) : TypeObjectModel<DualBaseModel, DualFieldModel, DualAlternateModel>(TypeKindModel.Dual, Name, Description)
{ }

public record class DualArgModel(
  string Dual,
  string Description
) : ObjArgModel(Description)
  , IDualModel
{ }

public record class DualBaseModel(
  string Dual,
  string Description
) : ObjBaseModel<DualArgModel>(Description)
  , IDualModel
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

public interface IDualModel
{
  string Dual { get; }
  bool IsTypeParam { get; }
}
