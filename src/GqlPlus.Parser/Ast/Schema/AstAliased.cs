namespace GqlPlus.Ast.Schema;

internal abstract record class AstAliased(
  ITokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IAstAliased
  , IAstSetAliases
{
  public string[] Aliases { get; set; } = [];
  IEnumerable<string> IAstAliased.Aliases => Aliases;

  public virtual bool Equals(AstAliased? other)
    => other is IAstAliased aliased && Equals(aliased);
  public bool Equals(IAstAliased? other)
    => base.Equals(other)
    && Aliases.OrderedEqual(other.Aliases);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Aliases.Length);
  public bool IsNameOrAlias(string id)
    => Name == id || Aliases.Contains(id);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Aliases.Bracket("[", "]", true));
  void IAstSetAliases.SetAliases(IEnumerable<string> aliases)
    => Aliases = [.. aliases];
}

internal interface IAstSetAliases
  : IAstSetDescription
{
  void SetAliases(IEnumerable<string> aliases);
}
