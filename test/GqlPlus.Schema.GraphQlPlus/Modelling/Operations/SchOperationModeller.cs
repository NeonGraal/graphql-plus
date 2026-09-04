namespace GqlPlus.Schema.Modelling;

internal class SchOperationModeller(
  ISchModellerRepository repo
) : ModellerBase<IAstSchemaOperation, ISch_Operation>
{
  private readonly Modeller<IAstModifier, ISch_Modifiers> _modifierModeller = repo.ModellerFor<IAstModifier, ISch_Modifiers>();

  internal static IModeller<IAstSchemaOperation, ISch_Operation> Factory(ISchModellerRepository repo)
    => new SchOperationModeller(repo);

  protected override ISch_Operation ToModel(IAstSchemaOperation ast, IMap<GqlpTypeKind> typeKinds)
  {
    Dictionary<ISch_Name, ISch_OpVariable> variables = [];
    Dictionary<ISch_Name, ISch_OpFragment> fragments = [];
    Dictionary<ISch_Path, ICollection<ISch_OpSelection>> selections = [];

    Sch_OperationObject operation = new(
     SchModellerHelpers.Desc(ast.Description),
     SchModellerHelpers.MakeName(ast.Name),
     SchModellerHelpers.MakeAliases(ast.Aliases),
      SchModellerHelpers.MakeName(ast.Category),
      variables, [], fragments, selections,
      [.. _modifierModeller.ToModels(ast.Modifiers, typeKinds)])
   //Variables = _variable.ToModels(ast.Variables, typeKinds).ToMap(f => f.Name),
   //Directives = _directive.ToModels(ast.Directives, typeKinds),
   //Fragments = _fragment.ToModels(ast.Fragments, typeKinds).ToMap(f => f.Name),
   //Result = ast.Domain?.Name.IsWhiteSpace() == false ? _result.ToModel(ast.Domain, typeKinds) : null,
   //Selections = ast.Selections.ToMap(
   //    k => k.Key,
   //    v => _selection.ToModels(v.Value, typeKinds)),
   ;

    Sch_Operation result = new() {
      As__Operation = operation
    };
    return result;
  }
}
