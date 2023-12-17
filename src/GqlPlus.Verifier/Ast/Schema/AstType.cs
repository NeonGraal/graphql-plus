using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstType(TokenAt At, string Name, string Description)
  : AstDeclaration(At, Name, Description), IAstType
{
  public abstract string Label { get; }
}

public interface IAstType
{
  string Name { get; }
  string Label { get; }

}
