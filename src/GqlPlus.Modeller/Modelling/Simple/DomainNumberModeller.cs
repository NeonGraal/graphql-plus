using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Simple;

internal class DomainNumberModeller
  : ModellerDomain<IAstDomainRange, DomainRangeModel>
{
  protected override BaseDomainModel<DomainRangeModel> ToModel(IAstDomain<IAstDomainRange> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Number, ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
      AllItems = ToAllItems(ast, typeKinds),
    };

  protected override DomainRangeModel ToItem(IAstDomainRange ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Lower, ast.Upper, ast.Excludes, ast.Description);
}
