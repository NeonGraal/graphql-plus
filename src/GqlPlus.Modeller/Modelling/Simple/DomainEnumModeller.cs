namespace GqlPlus.Modelling.Simple;

internal class DomainEnumModeller
  : ModellerDomain<IGqlpDomainLabel, DomainLabelModel>
{
  protected override BaseDomainModel<DomainLabelModel> ToModel(IGqlpDomain<IGqlpDomainLabel> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Enum, ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainLabelModel ToItem(IGqlpDomainLabel ast, IMap<TypeKindModel> typeKinds)
    => new(ast.EnumType ?? "", ast.EnumItem, ast.Excludes);
}
