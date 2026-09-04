using GqlPlus.Ast.Operation;

namespace GqlPlus.Schema.Modelling;

internal class SchOpArgumentModeller
  : ModellerBase<IAstArg, ISch_OpArgument>
{
  internal static IModeller<IAstArg, ISch_OpArgument> Factory(ISchModellerRepository _)
    => new SchOpArgumentModeller();

  protected override ISch_OpArgument ToModel(IAstArg ast, IMap<GqlpTypeKind> typeKinds)
    => new Sch_OpArgument();
}
