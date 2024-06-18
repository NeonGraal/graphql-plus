using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public abstract record class AstObjBase<TObjBase>(
  TokenAt At,
  string Name,
  string Description
) : AstDescribed(At, Name, Description)
  , IEquatable<AstObjBase<TObjBase>>
  , IGqlpObjBase<TObjBase>
  where TObjBase : IGqlpObjBase<TObjBase>
{
  public bool IsTypeParameter { get; set; }
  public TObjBase[] TypeArguments { get; set; } = [];

  public abstract string Label { get; }

  public string TypeName => IsTypeParameter ? Name.Prefixed("$") : Name;

  public string FullType => TypeArguments
    .Bracket("<", ">")
    .Prepend(TypeName)
    .Joined();

  IEnumerable<TObjBase> IGqlpObjBase<TObjBase>.TypeArguments => TypeArguments;

  public virtual bool Equals(AstObjBase<TObjBase>? other)
    => base.Equals(other)
    && IsTypeParameter == other!.IsTypeParameter
    && TypeArguments.SequenceEqual(other.TypeArguments);
  public bool Equals(TObjBase? other)
    => Equals(other as AstObjBase<TObjBase>);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), IsTypeParameter, TypeArguments.Length);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      TypeName
    }.Concat(TypeArguments.Bracket("<", ">"));
}
