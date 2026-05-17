namespace GqlPlus.Schema.Modelling;

internal sealed class SchInputModeller(
  ISchModellerRepository repo
) : SchObjectModellerBase<IAstInputField, ISch_InputField>(repo)
{
  internal static IModeller<IAstObject<IAstInputField>, ISch_Type> Factory(ISchModellerRepository repo)
    => new SchInputModeller(repo);
  protected override Sch_TypeKind TypeKind => Sch_TypeKind.Input;

  protected override ISch_InputField MakeField(IAstInputField ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_InputField result = new();
    result.As__InputField = new Sch_InputFieldObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeAliases(ast.Aliases),
      MakeInputFieldType(ast, typeKinds));
    return result;
  }

  protected override ISch_Type Wrap(ISch_TypeObject<Sch_TypeKind, ISch_InputField> typeObject)
    => new Sch_Type {
      As_TypeKindInput = typeObject,
      As__Type = new Sch_TypeObject(),
    };
}
