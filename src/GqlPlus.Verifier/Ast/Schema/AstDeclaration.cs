
namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstDeclaration(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description)
{
  internal abstract string GroupName { get; }
}
