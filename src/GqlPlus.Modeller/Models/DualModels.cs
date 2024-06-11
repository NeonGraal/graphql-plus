namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name
) : TypeObjectModel<DualBaseModel, DualFieldModel>(TypeKindModel.Dual, Name)
{
  protected override string? ParentName(ObjDescribedModel<DualBaseModel>? parent)
    => parent?.Base.Dual;
}

public record class DualBaseModel(
  string Dual
) : ObjBaseModel<DualBaseModel>
{ }

public record class DualFieldModel(
  string Name,
  ObjDescribedModel<DualBaseModel> Type
) : ObjFieldModel<DualBaseModel>(Name, Type)
{ }
