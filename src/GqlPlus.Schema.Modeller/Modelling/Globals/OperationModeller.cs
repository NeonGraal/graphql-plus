using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling.Globals;

internal class OperationModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSchemaOperation, OperationModel>
{
  private readonly Modeller<IAstDirective, OpDirectiveModel> _directives = modellers.ModellerFor<IAstDirective, OpDirectiveModel>();
  private readonly Modeller<IAstFragment, OpFragmentModel> _fragments = modellers.ModellerFor<IAstFragment, OpFragmentModel>();
  private readonly Modeller<IAstModifier, ModifierModel> _modifiers = modellers.ModellerFor<IAstModifier, ModifierModel>();
  private readonly Modeller<IAstTypeRef, OpResultModel> _result = modellers.ModellerFor<IAstTypeRef, OpResultModel>();
  // private readonly Modeller<IAstSelection, OpSelectionModel> _selections = modellers.ModellerFor<IAstSelection, OpSelectionModel>();
  private readonly Modeller<IAstVariable, OpVariableModel> _variables = modellers.ModellerFor<IAstVariable, OpVariableModel>();

  protected override OperationModel ToModel(IAstSchemaOperation ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Category, "") {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Variables = _variables.ToModels(ast.Variables, typeKinds).ToMap(f => f.Name),
      Directives = _directives.ToModels(ast.Directives, typeKinds),
      Fragments = _fragments.ToModels(ast.Fragments, typeKinds).ToMap(f => f.Name),
      Result = ast.Domain?.Name.IsWhiteSpace() == false ? _result.ToModel(ast.Domain, typeKinds) : null,
      // Todo: Selections = _selections.ToModels(ast.Selections, typeKinds),
      Modifiers = _modifiers.ToModels(ast.Modifiers, typeKinds),
    };

  internal static OperationModeller Factory(IModellerRepository repo) => new(repo);
}

internal class OpDirectiveModeller
  : ModellerBase<IAstDirective, OpDirectiveModel>
{
  protected override OpDirectiveModel ToModel(IAstDirective ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Identifier, "");

  internal static OpDirectiveModeller Factory(IModellerRepository _) => new();
}

internal class OpFragmentModeller
  : ModellerBase<IAstFragment, OpFragmentModel>
{
  protected override OpFragmentModel ToModel(IAstFragment ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Identifier, ast.OnType.TypeRef(TypeKindModel.Output), "");

  internal static OpFragmentModeller Factory(IModellerRepository _) => new();
}

internal class OpResultModeller
  : ModellerBase<IAstTypeRef, OpResultModel>
{
  protected override OpResultModel ToModel(IAstTypeRef ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name.TypeRef(TypeKindModel.Output));

  internal static OpResultModeller Factory(IModellerRepository _) => new();
}

internal class OpVariableModeller
  : ModellerBase<IAstVariable, OpVariableModel>
{
  protected override OpVariableModel ToModel(IAstVariable ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Identifier, ast.Type.TypeRef(TypeKindModel.Input), null, "");

  internal static OpVariableModeller Factory(IModellerRepository _) => new();
}
