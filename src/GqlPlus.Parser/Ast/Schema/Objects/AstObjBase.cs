using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjBase<TObjArg>(
  ITokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IEquatable<AstObjBase<TObjArg>>
  , IGqlpObjBase<TObjArg>
  where TObjArg : IGqlpObjArg
{
  public TObjArg[] BaseArgs { get; set; } = [];

  public override string FullType => BaseArgs
    .Bracket("<", ">")
    .Prepend(base.FullType)
    .Joined();

  IEnumerable<IGqlpObjArg> IGqlpObjBase.Args => BaseArgs.Cast<IGqlpObjArg>();
  IEnumerable<TObjArg> IGqlpObjBase<TObjArg>.BaseArgs => BaseArgs;
  bool IEquatable<IGqlpObjBase>.Equals(IGqlpObjBase? other)
    => Equals(other as AstObjBase<TObjArg>);

  public virtual bool Equals(AstObjBase<TObjArg>? other)
    => base.Equals(other)
    && BaseArgs.SequenceEqual(other.BaseArgs);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), BaseArgs.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(BaseArgs.Bracket("<", ">"));
}
