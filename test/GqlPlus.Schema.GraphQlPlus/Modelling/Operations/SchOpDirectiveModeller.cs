using GqlPlus.Ast.Operation;

namespace GqlPlus.Schema.Modelling;

internal class SchOpDirectiveModeller
  : ModellerBase<IAstDirective, ISch_OpDirective>
{
  internal static IModeller<IAstDirective, ISch_OpDirective> Factory(ISchModellerRepository _)
    => new SchOpDirectiveModeller();

  protected override ISch_OpDirective ToModel(IAstDirective ast, IMap<GqlpTypeKind> typeKinds)
    => new Sch_OpDirective();
}
