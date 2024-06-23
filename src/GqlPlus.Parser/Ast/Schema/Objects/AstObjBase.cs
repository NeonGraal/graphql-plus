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
  where TObjBase : IGqlpObjBase
{
  public bool IsTypeParameter { get; set; }
  public TObjBase[] BaseArguments { get; set; } = [];

  public abstract string Label { get; }

  public string TypeName => IsTypeParameter ? Name.Prefixed("$") : Name;

  public string FullType => BaseArguments
    .Bracket("<", ">")
    .Prepend(TypeName)
    .Joined();

  IEnumerable<IGqlpObjBase> IGqlpObjBase.Arguments => BaseArguments.Cast<IGqlpObjBase>();
  IEnumerable<TObjBase> IGqlpObjBase<TObjBase>.BaseArguments => BaseArguments;
  bool IEquatable<IGqlpObjBase>.Equals(IGqlpObjBase? other)
    => Equals(other as AstObjBase<TObjBase>);

  public virtual bool Equals(AstObjBase<TObjBase>? other)
    => base.Equals(other)
    && IsTypeParameter == other!.IsTypeParameter
    && BaseArguments.SequenceEqual(other.BaseArguments);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), IsTypeParameter, BaseArguments.Length);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      TypeName
    }.Concat(BaseArguments.Bracket("<", ">"));
}
