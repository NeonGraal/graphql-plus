using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstAliased(
  ITokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IGqlpAliased
  , IAstSetAliases
{
  public string[] Aliases { get; set; } = [];
  IEnumerable<string> IGqlpAliased.Aliases => Aliases;


  public virtual bool Equals(AstAliased? other)
    => other is IGqlpAliased aliased && Equals(aliased);
  public bool Equals(IGqlpAliased? other)
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
