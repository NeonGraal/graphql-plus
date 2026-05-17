using System.Linq;

namespace GqlPlus.Schema.Modelling;

internal sealed class SchCategoryModeller(
  IModeller<IAstModifier, ISch_Modifiers> modifierModeller
) : ModellerBase<IAstSchemaCategory, ISch_Category>
{
  private readonly IModeller<IAstModifier, ISch_Modifiers> _modifierModeller = modifierModeller;

  protected override ISch_Category ToModel(IAstSchemaCategory ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_Category result = new();
    result.As__Category = new Sch_CategoryObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeAliases(ast.Aliases),
      (Sch_Resolution)ast.CategoryOption,
      SchModellerHelpers.MakeTypeRef(ast.Output.Name, GqlpTypeKind.Output, typeKinds),
      [.. _modifierModeller.ToModels(ast.Modifiers, typeKinds)]);
    return result;
  }
}
