using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

public abstract record class AstSimple(
  TokenAt At,
  string Name,
  string Description
) : AstType<string>(At, Name, Description)
{ }

public abstract record class AstSimple<TMember>(
  TokenAt At,
  string Name,
  string Description,
  TMember[] Members
) : AstSimple(At, Name, Description)
  , IGqlpSimple<TMember>
  where TMember : IGqlpNamed
{
  public IEnumerable<TMember> Items => Members;

  public virtual bool Equals(AstSimple<TMember>? other)
    => base.Equals(other)
      && Members.SequenceEqual(other.Members);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Members.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Parent.Prefixed(":"))
      .Concat(Members.Bracket());
}
