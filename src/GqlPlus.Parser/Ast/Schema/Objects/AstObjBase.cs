using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjBase<TObjArg>(
  TokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
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

  public bool Equals(IGqlpObjBase? other)
    => other is IGqlpObjBase<TObjArg> objBase && Equals(objBase);
  public virtual bool Equals(AstObjBase<TObjArg>? other)
    => other is IGqlpObjBase<TObjArg> objBase && Equals(objBase);
  public bool Equals([NotNullWhen(true)] IGqlpObjBase<TObjArg>? other)
    => base.Equals(other)
    && BaseArgs.SequenceEqual(other.BaseArgs);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), BaseArgs.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(BaseArgs.Bracket("<", ">"));
}
