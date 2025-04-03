using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstDescribed(
  TokenAt At,
  string Description
) : AstAbbreviated(At)
  , IEquatable<AstDescribed>
  , IGqlpDescribed
  , IAstSetDescription
{
  public string Description { get; internal set; } = Description;

  public virtual bool Equals(AstDescribed? other)
    => base.Equals(other)
    && Description.Equals(other.Description, StringComparison.Ordinal);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Description);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend(Description.Quoted("'"));
  void IAstSetDescription.SetDescription(string description)
    => Description = description;
}

internal interface IAstSetDescription
{
  void SetDescription(string description);
}
