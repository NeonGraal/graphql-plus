using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

internal class OperationModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSchemaOperation, OperationModel>
{
  private readonly Modeller<IAstDirective, OpDirectiveModel> _directive = modellers.ModellerFor<IAstDirective, OpDirectiveModel>();
  private readonly Modeller<IAstFragment, OpFragmentModel> _fragment = modellers.ModellerFor<IAstFragment, OpFragmentModel>();
  private readonly Modeller<IAstModifier, ModifierModel> _modifier = modellers.ModellerFor<IAstModifier, ModifierModel>();
  private readonly Modeller<IAstTypeRef, OpResultModel> _result = modellers.ModellerFor<IAstTypeRef, OpResultModel>();
  private readonly Modeller<IAstSelection, OpSelectionModel> _selection = modellers.ModellerFor<IAstSelection, OpSelectionModel>();
  private readonly Modeller<IAstVariable, OpVariableModel> _variable = modellers.ModellerFor<IAstVariable, OpVariableModel>();

  protected override OperationModel ToModel(IAstSchemaOperation ast, IMap<TypeKindModel> typeKinds)
  {
    Map<OpSelectionModel[]> selections = [];
    AddSelections(selections, "", [.. ast.Selections], typeKinds);
    foreach (IAstFragment fragment in ast.Fragments) {
      AddSelections(selections, fragment.Identifier, [.. fragment.Selections], typeKinds);
    }

    return new(ast.Name, ast.Category, "") {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Variables = _variable.ToModels(ast.Variables, typeKinds).ToMap(f => f.Name),
      Directives = _directive.ToModels(ast.Directives, typeKinds),
      Fragments = _fragment.ToModels(ast.Fragments, typeKinds).ToMap(f => f.Name),
      Result = ast.Domain?.Name.IsWhiteSpace() == false ? _result.ToModel(ast.Domain, typeKinds) : null,
      Selections = selections,
      Modifiers = _modifier.ToModels(ast.Modifiers, typeKinds),
    };
  }

  private void AddSelections(Map<OpSelectionModel[]> models, string path, IAstSelection[] ast, IMap<TypeKindModel> typeKinds)
  {
    if (ast.Length == 0) {
      return;
    }

    List<OpSelectionModel> list = [];
    for (int i = 0; i < ast.Length; i++) {
      list.Add(_selection.ToModel(ast[i], typeKinds));
      if (ast[i] is IAstSelections selections) {
        AddSelections(models, $"{path}.{i + 1}", [.. selections.Selections], typeKinds);
      }
    }

    models[path] = [.. list];
  }

  internal static OperationModeller Factory(IModellerRepository repo) => new(repo);
}
