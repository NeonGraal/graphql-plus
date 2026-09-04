namespace GqlPlus.Schema.Modelling;

internal class SchOpResultModeller
  : ModellerBase<IAstTypeRef, ISch_OpResult>
{
  internal static IModeller<IAstTypeRef, ISch_OpResult> Factory(ISchModellerRepository _)
    => new SchOpResultModeller();

  protected override ISch_OpResult ToModel(IAstTypeRef ast, IMap<GqlpTypeKind> typeKinds)
    => new Sch_OpResult();
}
