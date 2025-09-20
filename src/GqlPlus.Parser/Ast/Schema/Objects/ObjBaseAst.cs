using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal record class ObjBaseAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IGqlpObjBase
{
  internal override string Abbr => "OB";
  public override string Label => "Obj";

  public IGqlpObjArg[] Args { get; set; } = [];

  public override string FullType => Args
    .Bracket("<", ">")
    .Prepend(base.FullType)
    .Joined();

  IEnumerable<IGqlpObjArg> IGqlpObjBase.Args => Args.Cast<IGqlpObjArg>();

  public void SetName(string name) => Name = name;

  public virtual bool Equals(ObjBaseAst? other)
    => other is IGqlpObjBase objBase && Equals(objBase);
  public bool Equals([NotNullWhen(true)] IGqlpObjBase? other)
    => base.Equals(other)
    && Args.SequenceEqual(other.Args);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Args.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Args.Bracket("<", ">"));
}
