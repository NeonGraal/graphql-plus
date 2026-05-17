namespace GqlPlus.Schema.Modelling;

internal sealed class SchDualModeller(
  ISchModellerRepository repo
) : SchObjectModellerBase<IAstDualField, ISch_DualField>(repo)
{
  internal static IModeller<IAstObject<IAstDualField>, ISch_Type> Factory(ISchModellerRepository repo)
    => new SchDualModeller(repo);
  protected override Sch_TypeKind TypeKind => Sch_TypeKind.Dual;

  protected override ISch_DualField MakeField(IAstDualField ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_DualField result = new();
    result.As__DualField = new Sch_DualFieldObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeAliases(ast.Aliases),
      MakeObjFieldType(ast, typeKinds));
    return result;
  }

  protected override ISch_Type Wrap(ISch_TypeObject<Sch_TypeKind, ISch_DualField> typeObject)
    => new Sch_Type {
      As_TypeKindDual = typeObject,
      As__Type = new Sch_TypeObject(),
    };
}
