﻿namespace GqlPlus.Modelling.Simple;

internal class DomainStringModeller
  : ModellerDomain<IGqlpDomainRegex, DomainRegexModel>
{
  protected override BaseDomainModel<DomainRegexModel> ToModel(IGqlpDomain<IGqlpDomainRegex> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.String, ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
      AllItems = ToAllItems(ast, typeKinds),
    };

  protected override DomainRegexModel ToItem(IGqlpDomainRegex ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Pattern, ast.Excludes);
}
