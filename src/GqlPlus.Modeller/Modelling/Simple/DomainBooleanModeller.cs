namespace GqlPlus.Modelling.Simple;

internal class DomainBooleanModeller
  : ModellerDomain<IGqlpDomainTrueFalse, DomainTrueFalseModel>
{
  protected override BaseDomainModel<DomainTrueFalseModel> ToModel(IGqlpDomain<IGqlpDomainTrueFalse> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Boolean, ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
      AllItems = ToAllItems(ast, typeKinds),
    };

  protected override DomainTrueFalseModel ToItem(IGqlpDomainTrueFalse ast, IMap<TypeKindModel> typeKinds)
    => new(ast.IsTrue, ast.Excludes);
}
