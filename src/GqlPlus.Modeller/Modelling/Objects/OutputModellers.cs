﻿namespace GqlPlus.Modelling.Objects;

internal class OutputModeller(
  ObjectModellers<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, OutputBaseModel, OutputFieldModel, OutputAlternateModel> modellers
) : ModellerObject<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>(TypeKindModel.Output, modellers)
{
  protected override TypeOutputModel ToModel(IGqlpOutputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams, typeKinds),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class OutputArgModeller(
  IModeller<IGqlpDualArg, DualArgModel> dual
) : ModellerObjArg<IGqlpOutputArg, OutputArgModel>
{
  protected override OutputArgModel ToModel(IGqlpOutputArg ast, IMap<TypeKindModel> typeKinds)
      => string.IsNullOrWhiteSpace(ast.EnumLabel)
      ? typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
        ? new(typeKind, "", "") {
          Dual = dual.ToModel(ast.ToDual, typeKinds)
        }
        : new(typeKind, ast.Name, ast.Description) {
          IsTypeParam = ast.IsTypeParam,
        }
      : new(TypeKindModel.Enum, ast.Name, ast.Description) { EnumLabel = ast.EnumLabel };
}

internal class OutputBaseModeller(
  IModeller<IGqlpOutputArg, OutputArgModel> objArg,
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpOutputBase, IGqlpOutputArg, OutputBaseModel, OutputArgModel>(objArg)
{
  protected override OutputBaseModel ToModel(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new("", ast.Description) {
      IsTypeParam = ast.IsTypeParam,
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Name, ast.Description) {
      IsTypeParam = ast.IsTypeParam,
      Args = ModelArgs(ast, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputParam, InputParamModel> parameter,
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase
) : ModellerObjField<IGqlpOutputBase, IGqlpOutputField, OutputBaseModel, OutputFieldModel>(modifier, objBase)
{
  protected override OutputFieldModel FieldModel(IGqlpOutputField field, OutputBaseModel type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.EnumLabel)
      ? new(field.Name, type, field.Description) {
        Params = parameter.ToModels(field.Params, typeKinds),
      }
      : new(field.Name, type, field.Description) { // or should it be `type`
        Enum = new(field.Name, type.Name, field.EnumLabel!, type.Description)
      };
}

internal class OutputAlternateModeller(
  IModeller<IGqlpModifier, CollectionModel> collection,
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase
) : ModellerObjAlternate<IGqlpOutputBase, IGqlpOutputAlternate, OutputBaseModel, OutputAlternateModel>(collection, objBase)
{
  protected override OutputAlternateModel AlternateModel(OutputBaseModel type)
    => new(type);
}
