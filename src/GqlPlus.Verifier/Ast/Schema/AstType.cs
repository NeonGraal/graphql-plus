namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstType(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description)
{
}
