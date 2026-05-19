namespace GqlPlus.Schema.Modelling;

internal sealed class SchCategoryModeller(
  ISchModellerRepository repo
) : ModellerBase<IAstSchemaCategory, ISch_Category>
{
  private readonly Modeller<IAstModifier, ISch_Modifiers> _modifierModeller = repo.ModellerFor<IAstModifier, ISch_Modifiers>();

  internal static IModeller<IAstSchemaCategory, ISch_Category> Factory(ISchModellerRepository repo)
    => new SchCategoryModeller(repo);

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
