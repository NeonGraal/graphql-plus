namespace GqlPlus.Ast.Schema;

internal class AstDeclarationChecks<TDeclaration>(
  BaseAstChecks<TDeclaration>.CreateBy<string> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAliasedChecks<TDeclaration>(createInput, createExpression)
  , IAstDeclarationChecks
  where TDeclaration : AstDeclaration
{
  public void Label_IsExpected(string input)
  {
    TDeclaration instance = CreateInput(input);

    string expectedLabel = typeof(TDeclaration).Name.Replace("DeclAst", "", StringComparison.Ordinal);

    Assert.Equal(expectedLabel, instance.Label);
  }
}

internal interface IAstDeclarationChecks
{
  void Label_IsExpected(string input);
}
