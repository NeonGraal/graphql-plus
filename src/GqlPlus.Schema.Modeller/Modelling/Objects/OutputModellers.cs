using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

internal class OutputModeller(
  IModellerRepository modellers
) : ModellerObject<IAstObject<IAstOutputField>, IAstOutputField, TypeOutputModel, OutputFieldModel>(TypeKindModel.Output, modellers)
{
  protected override TypeOutputModel ToModel(IAstObject<IAstOutputField> ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams, typeKinds),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };

  internal static OutputModeller Factory(IModellerRepository r) => new(r);
}

internal class OutputFieldModeller(
  IModellerRepository modellers
) : ModellerObjField<IAstOutputField, OutputFieldModel>(modellers)
{
  private readonly IModeller<IAstInputParam, InputParamModel> _parameter = modellers.ModellerFor<IAstInputParam, InputParamModel>();

  protected override OutputFieldModel FieldModel(IAstOutputField field, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => field.EnumValue is null
      ? new(field.Name, type, field.Description) {
        Parameter = _parameter.TryModel(field.Parameter, typeKinds),
      }
      : new(field.Name, type, field.Description) {
        Enum = new(field.Name, type.Name, field.EnumValue.EnumLabel, type.Description)
      };

  internal static OutputFieldModeller Factory(IModellerRepository r) => new(r);
}
