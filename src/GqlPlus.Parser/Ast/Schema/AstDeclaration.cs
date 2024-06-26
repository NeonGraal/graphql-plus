using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstDeclaration(
  TokenAt At,
  string Name,
  string Description
) : AstAliased(At, Name, Description)
  , IGqlpDeclaration
{
  public abstract string Label { get; }
}
