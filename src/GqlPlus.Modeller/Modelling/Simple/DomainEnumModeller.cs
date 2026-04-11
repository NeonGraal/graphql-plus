namespace GqlPlus.Modelling.Simple;

internal class DomainEnumModeller
  : ModellerDomain<IAstDomainLabel, DomainLabelModel>
{
  protected override BaseDomainModel<DomainLabelModel> ToModel(IAstDomain<IAstDomainLabel> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Enum, ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
      AllItems = ToAllItems(ast, typeKinds),
    };

  protected override DomainLabelModel ToItem(IAstDomainLabel ast, IMap<TypeKindModel> typeKinds)
    => new(ast.EnumType.IfWhiteSpace(), ast.EnumItem, ast.Excludes, ast.Description);
}
