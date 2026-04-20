namespace GqlPlus.Ast.Schema;

internal abstract record class AstDeclaration(
  ITokenAt At,
  string Name,
  string Description
) : AstAliased(At, Name, Description)
  , IAstDeclaration
{
  public abstract string Label { get; }
}
