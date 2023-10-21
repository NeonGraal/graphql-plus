namespace GqlPlus.Verifier.Ast;

internal abstract record class AstAliased(ParseAt At, string Name, string Description)
  : AstNamed(At, Name), IEquatable<AstAliased>
{
  public string[] Aliases { get; set; } = Array.Empty<string>();

  public virtual bool Equals(AstAliased? other)
    => base.Equals(other)
    && Description.Equals(other.Description)
    && Aliases.OrderedEqual(other.Aliases);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Description, Aliases.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend(Description.Quoted("\""))
      .Concat(Aliases.Bracket("[", "]"));
}
