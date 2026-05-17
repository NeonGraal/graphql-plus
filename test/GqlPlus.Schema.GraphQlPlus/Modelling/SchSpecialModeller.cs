namespace GqlPlus.Schema.Modelling;

internal sealed class SchSpecialModeller
  : ModellerBase<IAstTypeSpecial, ISch_Type>
{
  internal static IModeller<IAstTypeSpecial, ISch_Type> Factory(ISchModellerRepository _)
    => new SchSpecialModeller();
  protected override ISch_Type ToModel(IAstTypeSpecial ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_TypeKind kind = ast.Kind == TypeKind.Internal ? Sch_TypeKind.Internal : Sch_TypeKind.Basic;
    Sch_BaseType<Sch_TypeKind> baseType = new() {
      As__BaseType = new Sch_BaseTypeObject<Sch_TypeKind>(
        SchModellerHelpers.Desc(ast.Description),
        SchModellerHelpers.MakeName(ast.Name),
        SchModellerHelpers.MakeAliases(ast.Aliases),
        kind),
    };

    return ast.Kind == TypeKind.Internal
      ? new Sch_Type {
        As_TypeKindInternal = baseType,
        As__Type = new Sch_TypeObject(),
      }
      : new Sch_Type {
        As_TypeKindBasic = baseType,
        As__Type = new Sch_TypeObject(),
      };
  }
}
