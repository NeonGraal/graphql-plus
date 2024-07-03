using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjBase<TObjArg>(
  TokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IEquatable<AstObjBase<TObjArg>>
  , IGqlpObjBase<TObjArg>
  where TObjArg : IGqlpObjArgument
{
  public TObjArg[] BaseArguments { get; set; } = [];

  public override string FullType => BaseArguments
    .Bracket("<", ">")
    .Prepend(base.FullType)
    .Joined();

  IEnumerable<IGqlpObjArgument> IGqlpObjBase.Arguments => BaseArguments.Cast<IGqlpObjArgument>();
  IEnumerable<TObjArg> IGqlpObjBase<TObjArg>.BaseArguments => BaseArguments;
  bool IEquatable<IGqlpObjBase>.Equals(IGqlpObjBase? other)
    => Equals(other as AstObjBase<TObjArg>);

  public virtual bool Equals(AstObjBase<TObjArg>? other)
    => base.Equals(other)
    && BaseArguments.SequenceEqual(other.BaseArguments);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), BaseArguments.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(BaseArguments.Bracket("<", ">"));
}
