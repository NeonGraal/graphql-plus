using GqlPlus.Ast.Operation;

namespace GqlPlus.Schema.Modelling;

internal class SchOpVariableModeller
  : ModellerBase<IAstVariable, ISch_OpVariable>
{
  internal static IModeller<IAstVariable, ISch_OpVariable> Factory(ISchModellerRepository _)
    => new SchOpVariableModeller();

  protected override ISch_OpVariable ToModel(IAstVariable ast, IMap<GqlpTypeKind> typeKinds)
    => new Sch_OpVariable();
}
