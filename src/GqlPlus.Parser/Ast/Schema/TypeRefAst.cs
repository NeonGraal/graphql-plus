using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

internal record class TypeRefAst(
  TokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IGqlpTypeRef
{
  public TypeRefAst(TokenAt at, string name)
    : this(at, name, "")
  { }

  internal override string Abbr => "Tr";
}
