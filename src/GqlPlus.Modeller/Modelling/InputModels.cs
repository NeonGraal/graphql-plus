using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public record class TypeInputModel(
  string Name
) : TypeObjectModel<InputBaseModel, InputFieldModel>(TypeKindModel.Input, Name)
{
  protected override TypeInputModel Apply(Map<IObjBaseModel> arguments)
    => throw new NotImplementedException();

  protected override string BaseName(InputBaseModel? objBase)
    => objBase?.Input ?? "";
}

public record class InputBaseModel(
  string Input
) : ObjBaseModel<ObjRefModel<InputBaseModel>>
{
  internal DualBaseModel? Dual { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => Dual is null
    ? IsTypeParameter
      ? new(Input, "_TypeParameter")
      : base.Render(context)
        .Add("input", Input)
    : Dual.Render(context);
}

public record class InputFieldModel(
  string Name,
  ObjRefModel<InputBaseModel> Type
) : ObjFieldModel<InputBaseModel>(Name, Type)
{
  internal ConstantModel? Default { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("default", Default?.Render(context));
}

public record class InputParameterModel(
  ObjDescribedModel<ObjRefModel<InputBaseModel>> Type
) : ModelBase
{
  internal ModifierModel[] Modifiers { get; set; } = [];
  public ConstantModel? DefaultValue { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add(Type, context)
      .Add("modifiers", Modifiers.Render(context, flow: true))
      .Add("default", DefaultValue?.Render(context));
}

internal class InputModeller(
  IAlternateModeller<IGqlpInputBase, InputBaseModel> alternate,
  IModeller<IGqlpInputField, InputFieldModel> objField,
  IModeller<IGqlpInputBase, InputBaseModel> objBase
) : ModellerObject<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, TypeInputModel, InputBaseModel, InputFieldModel>(TypeKindModel.Input, alternate, objField, objBase)
{
  protected override TypeInputModel ToModel(IGqlpInputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class InputBaseModeller(
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpInputBase, InputBaseModel>
{
  protected override InputBaseModel ToModel(IGqlpInputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Input, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(ast.Input) {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Input) {
      IsTypeParameter = ast.IsTypeParameter,
      TypeArguments = ModelArguments(ast, typeKinds),
    };
}

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> refBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerObjField<IGqlpInputBase, IGqlpInputField, InputBaseModel, InputFieldModel>(modifier, refBase)
{
  protected override InputFieldModel FieldModel(IGqlpInputField ast, ObjRefModel<InputBaseModel> type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type) {
      Default = constant.TryModel(ast.DefaultValue, typeKinds),
    };
}

internal class InputParameterModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> objBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerBase<IGqlpInputParameter, InputParameterModel>
{
  protected override InputParameterModel ToModel(IGqlpInputParameter ast, IMap<TypeKindModel> typeKinds)
  {
    InputBaseModel typeModel = objBase.ToModel(ast.Type, typeKinds);
    return new(new(new(typeModel)) { Description = ast.Type.Description }) {
      Modifiers = modifier.ToModels<ModifierModel>(ast.Modifiers, typeKinds),
      DefaultValue = constant.TryModel(ast.DefaultValue, typeKinds),
    };
  }
}
