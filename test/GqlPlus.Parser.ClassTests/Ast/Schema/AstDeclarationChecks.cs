namespace GqlPlus.Ast.Schema;

internal class AstDeclarationChecks<TDeclaration>(
  BaseAstChecks<TDeclaration>.CreateBy<string> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstDeclarationChecks<string, TDeclaration>(createInput, createExpression)
  where TDeclaration : AstDeclaration
{
  protected override string InputName(string input) => input;
}
internal abstract class AstDeclarationChecks<TInput, TDeclaration>(
  BaseAstChecks<TDeclaration>.CreateBy<TInput> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAliasedChecks<TInput, TDeclaration>(createInput, createExpression)
  , IAstDeclarationChecks<TInput>
  where TDeclaration : AstDeclaration
{
  public void Label_IsExpected(TInput input)
  {
    TDeclaration instance = CreateInput(input);

    string expectedLabel = typeof(TDeclaration).Name
      .Replace("Decl", "", StringComparison.Ordinal)
      .Replace("Ast", "", StringComparison.Ordinal)
      .Split('`', 2)[0];

    Assert.Equal(expectedLabel, instance.Label);
  }
}

internal interface IAstDeclarationChecks<TInput>
  : IAstAliasedChecks<TInput>
{
  void Label_IsExpected(TInput input);
}
