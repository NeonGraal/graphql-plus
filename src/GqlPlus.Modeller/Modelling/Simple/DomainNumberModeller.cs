namespace GqlPlus.Modelling.Simple;

internal class DomainNumberModeller
  : ModellerDomain<IGqlpDomainRange, DomainRangeModel>
{
  protected override BaseDomainModel<DomainRangeModel> ToModel(IGqlpDomain<IGqlpDomainRange> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Number, ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
      AllItems = ToAllItems(ast, typeKinds),
    };

  protected override DomainRangeModel ToItem(IGqlpDomainRange ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Lower, ast.Upper, ast.Excludes, ast.Description);
}
