using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

public abstract record class AstDescribed(
  ITokenAt At,
  string Description
) : AstAbbreviated(At)
  , IGqlpDescribed
  , IAstSetDescription
{
  public string Description { get; internal set; } = Description;

  public bool Equals(IGqlpDescribed? other)
    => base.Equals(other)
    && Description.Equals(other.Description, StringComparison.Ordinal);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Description);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend(Description.Quoted("'"));
  void IAstSetDescription.SetDescription(string description)
    => Description = description;

  protected string?[] DescriptionAt => [Description.Quoted("'"), At.ToString()];
}

internal interface IAstSetDescription
{
  void SetDescription(string description);
}
