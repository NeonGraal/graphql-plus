namespace GqlPlus.Verifier;

public record class ParseAt(TokenKind Kind, int Pos, string Next)
  : IEquatable<ParseAt>
{
  public virtual bool Equals(ParseAt? other) => true;
  public override int GetHashCode() => 0;
}
