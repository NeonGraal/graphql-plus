namespace GqlPlus.Modelling.Simple;

internal class DomainEnumModeller
  : ModellerDomain<IGqlpDomainMember, DomainMemberModel>
{
  protected override BaseDomainModel<DomainMemberModel> ToModel(IGqlpDomain<IGqlpDomainMember> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Enum, ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainMemberModel ToItem(IGqlpDomainMember ast, IMap<TypeKindModel> typeKinds)
    => new(ast.EnumType ?? "", ast.EnumItem, ast.Excludes);
}
