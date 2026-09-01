namespace GqlPlus.Ast.Operation;

internal class AstSelectionsChecks<TInput, TAst>(
  AstSelectionsChecks<TInput, TAst>.CreateSelections<TInput> createSelections
) : AstDirectivesChecks<TInput, TAst>((i, d) => createSelections(i, d, []))
  , IAstSelectionsChecks<TInput>
  where TAst : class, IAstDirectives, IAstSelections
{
  public delegate TAst CreateSelections<TBy>(TBy input, string[] directives, IAstSelection[] fields);

  public void AsIAstSelections_WithSelections(TInput input, string[] fields)
  {
    IAstSelection[] fieldsAst = [.. fields.Select(CreateSelection)];
    TAst fieldAst = createSelections(input, [], fieldsAst);

    IAstSelections selections = fieldAst;

    selections.ShouldNotBeNull().Selections.ShouldBeSameAs(fieldsAst);
  }

  private IAstSelection CreateSelection(string name)
    => new FieldAst(AstNulls.At, name);
}

internal interface IAstSelectionsChecks<TInput>
: IAstDirectivesChecks<TInput>
{
  void AsIAstSelections_WithSelections(TInput input, string[] fields);
}
