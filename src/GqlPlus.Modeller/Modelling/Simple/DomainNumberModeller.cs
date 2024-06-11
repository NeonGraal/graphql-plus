namespace GqlPlus.Modelling.Simple;

internal class DomainNumberModeller
  : ModellerDomain<IGqlpDomainRange, DomainRangeModel>
{
  protected override BaseDomainModel<DomainRangeModel> ToModel(IGqlpDomain<IGqlpDomainRange> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Number, ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainRangeModel ToItem(IGqlpDomainRange ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Lower, ast.Upper, ast.Excludes);
}
