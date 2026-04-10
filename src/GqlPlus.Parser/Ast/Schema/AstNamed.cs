using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstNamed(
  ITokenAt At,
  string Name,
  string Description
) : AstDescribed(At, Description)
  , IAstNamed
{
  public string Name { get; set; } = Name;

  public virtual bool Equals(AstNamed? other)
    => other is IAstNamed named && Equals(named);
  public bool Equals(IAstNamed? other)
    => base.Equals(other)
    && string.Equals(Name, other.Name, StringComparison.Ordinal);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Name);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Name);
}
