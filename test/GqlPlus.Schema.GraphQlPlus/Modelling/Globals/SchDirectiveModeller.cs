namespace GqlPlus.Schema.Modelling;

internal sealed class SchDirectiveModeller
  : ModellerBase<IAstSchemaDirective, ISch_Directive>
{
  protected override ISch_Directive ToModel(IAstSchemaDirective ast, IMap<GqlpTypeKind> typeKinds)
  {
    Sch_DirectiveObject directive = new(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Name),
      SchModellerHelpers.MakeAliases(ast.Aliases),
      ast.DirectiveOption == DirectiveOption.Repeatable,
      SchModellerHelpers.MakeLocations(ast.Locations)) {
      Parameter = ast.Parameter is null ? null : MakeParameter(ast.Parameter),
    };

    Sch_Directive result = new();
    result.As__Directive = directive;
    return result;
  }

  private static Sch_InputFieldType MakeParameter(IAstInputParam ast)
  {
    Sch_InputFieldType result = new();
    result.As__InputFieldType = new Sch_InputFieldTypeObject(
      SchModellerHelpers.Desc(ast.Description),
      SchModellerHelpers.MakeName(ast.Type.Name),
      [],
      []);
    return result;
  }
}
