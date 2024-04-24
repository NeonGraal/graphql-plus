using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Simple;

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
  , IAstSimple<TMember>
  where TMember : AstNamed
{
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

internal interface IAstSimple<TMember>
  : IAstType<string>
  where TMember : AstAbbreviated
{
  TMember[] Members { get; }
}
