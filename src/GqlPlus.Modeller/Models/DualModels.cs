﻿namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name
) : TypeObjectModel<DualBaseModel, DualFieldModel, DualAlternateModel>(TypeKindModel.Dual, Name)
{
  protected override string? ParentName(ObjDescribedModel<DualBaseModel>? parent)
    => parent?.Base.Dual;
}

public record class DualArgumentModel(
  string Dual
) : ObjArgumentModel
{ }

public record class DualBaseModel(
  string Dual
) : ObjBaseModel<DualArgumentModel>
{ }

public record class DualFieldModel(
  string Name,
  ObjDescribedModel<DualBaseModel> Type
) : ObjFieldModel<DualBaseModel>(Name, Type)
{ }

public record class DualAlternateModel(
  ObjDescribedModel<DualBaseModel> Type
) : ObjAlternateModel<DualBaseModel>(Type)
{ }
