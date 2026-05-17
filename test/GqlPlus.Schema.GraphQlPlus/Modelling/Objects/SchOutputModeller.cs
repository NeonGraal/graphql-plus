namespace GqlPlus.Schema.Modelling;

internal sealed class SchOutputModeller(
  IModeller<IAstModifier, ISch_Modifiers> modifierModeller
) : SchObjectModellerBase<IAstOutputField, ISch_OutputField>(modifierModeller)
{
  protected override Sch_TypeKind TypeKind => Sch_TypeKind.Output;

  protected override ISch_OutputField MakeField(IAstOutputField ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_OutputField result = new();
    result.As__OutputField = new Sch_OutputFieldObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeAliases(ast.Aliases),
      MakeOutputFieldType(ast, typeKinds));
    return result;
  }

  protected override ISch_Type Wrap(ISch_TypeObject<Sch_TypeKind, ISch_OutputField> typeObject)
    => new Sch_Type {
      As_TypeKindOutput = typeObject,
      As__Type = new Sch_TypeObject(),
    };
}
