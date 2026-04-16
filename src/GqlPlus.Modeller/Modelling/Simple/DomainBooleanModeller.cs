using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Simple;

internal class DomainBooleanModeller
  : ModellerDomain<IAstDomainTrueFalse, DomainTrueFalseModel>
{
  protected override BaseDomainModel<DomainTrueFalseModel> ToModel(IAstDomain<IAstDomainTrueFalse> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Boolean, ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
      AllItems = ToAllItems(ast, typeKinds),
    };

  protected override DomainTrueFalseModel ToItem(IAstDomainTrueFalse ast, IMap<TypeKindModel> typeKinds)
    => new(ast.IsTrue, ast.Excludes, ast.Description);

  internal static DomainBooleanModeller Factory(IModellerRepository _) => new();
}
