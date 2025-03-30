using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjType(
  TokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IEquatable<AstObjType>
  , IGqlpObjType
{
  public bool IsTypeParam { get; set; }

  public abstract string Label { get; }

  public string TypeName => IsTypeParam ? Name.Prefixed("$") : Name;

  public virtual string FullType => TypeName;

  public virtual bool Equals(AstObjType? other)
    => base.Equals(other)
    && IsTypeParam == other!.IsTypeParam;
  public override int GetHashCode()
  => HashCode.Combine(base.GetHashCode(), IsTypeParam);

  internal override IEnumerable<string?> GetFields()
    => [At.ToString(), TypeName];
}
