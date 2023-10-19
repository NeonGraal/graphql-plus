namespace GqlPlus.Verifier.Ast;

internal abstract record class AstAliased(ParseAt At, string Name)
  : AstNamed(At, Name), IEquatable<AstAliased>
{
  public string[] Aliases { get; set; } = Array.Empty<string>();

  public virtual bool Equals(AstAliased? other)
    => base.Equals(other)
    && Aliases.SequenceEqual(other.Aliases);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Aliases);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Aliases.Bracket("[", "]"));
}
