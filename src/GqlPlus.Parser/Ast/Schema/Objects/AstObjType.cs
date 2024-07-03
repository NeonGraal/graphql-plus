using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjType(
  TokenAt At,
  string Name,
  string Description
) : AstDescribed(At, Name, Description)
  , IEquatable<AstObjType>
  , IGqlpObjType
{
  public bool IsTypeParameter { get; set; }

  public abstract string Label { get; }

  public string TypeName => IsTypeParameter ? Name.Prefixed("$") : Name;

  public virtual string FullType => TypeName;

  public virtual bool Equals(AstObjType? other)
    => base.Equals(other)
    && IsTypeParameter == other!.IsTypeParameter;
  public override int GetHashCode()
  => HashCode.Combine(base.GetHashCode(), IsTypeParameter);

  internal override IEnumerable<string?> GetFields()
    => [At.ToString(), TypeName];
}
