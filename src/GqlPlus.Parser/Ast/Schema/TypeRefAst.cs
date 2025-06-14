using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

internal record class TypeRefAst(
  ITokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IGqlpTypeRef
{
  public TypeRefAst(TokenAt at, string name)
    : this(at, name, "")
  { }

  internal override string Abbr => "Tr";

  public bool Equals(IGqlpTypeRef other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
