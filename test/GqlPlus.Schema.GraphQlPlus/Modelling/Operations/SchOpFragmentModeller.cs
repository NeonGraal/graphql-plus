using GqlPlus.Ast.Operation;

namespace GqlPlus.Schema.Modelling;

internal class SchOpFragmentModeller
  : ModellerBase<IAstFragment, ISch_OpFragment>
{
  internal static IModeller<IAstFragment, ISch_OpFragment> Factory(ISchModellerRepository _)
    => new SchOpFragmentModeller();

  protected override ISch_OpFragment ToModel(IAstFragment ast, IMap<GqlpTypeKind> typeKinds)
    => new Sch_OpFragment();
}
