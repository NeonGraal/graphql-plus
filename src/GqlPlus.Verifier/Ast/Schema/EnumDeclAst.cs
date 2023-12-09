using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class EnumDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description), IEquatable<EnumDeclAst>
{
  public string? Extends { get; set; }
  public EnumValueAst[] Values { get; set; } = [];

  internal override string Abbr => "E";

  public EnumDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(EnumDeclAst? other)
    => base.Equals(other)
      && Extends.NullEqual(other.Extends)
      && Values.SequenceEqual(other.Values);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Extends, Values.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Extends.Prefixed(":"))
      .Concat(Values.Bracket());
}
