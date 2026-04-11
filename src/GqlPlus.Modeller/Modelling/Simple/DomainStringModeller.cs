namespace GqlPlus.Modelling.Simple;

internal class DomainStringModeller
  : ModellerDomain<IAstDomainRegex, DomainRegexModel>
{
  protected override BaseDomainModel<DomainRegexModel> ToModel(IAstDomain<IAstDomainRegex> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.String, ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
      AllItems = ToAllItems(ast, typeKinds),
    };

  protected override DomainRegexModel ToItem(IAstDomainRegex ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Pattern, ast.Excludes, ast.Description);
}
