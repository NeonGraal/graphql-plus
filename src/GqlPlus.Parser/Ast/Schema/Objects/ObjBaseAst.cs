namespace GqlPlus.Ast.Schema.Objects;

internal record class ObjBaseAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IAstObjBase
{
  internal override string Abbr => "OB";
  public IAstTypeArg[] Args { get; set; } = [];

  public override string FullType => Args
    .Bracket("<", ">")
    .Prepend(TypeName)
    .Joined();

  IEnumerable<IAstTypeArg> IAstObjBase.Args => Args.Cast<IAstTypeArg>();

  public void SetName(string name) => Name = name;

  public virtual bool Equals(ObjBaseAst? other)
    => other is IAstObjBase objBase && Equals(objBase);
  public bool Equals([NotNullWhen(true)] IAstObjBase? other)
    => base.Equals(other)
    && Args.SequenceEqual(other.Args);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Args.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Args.Bracket("<", ">"));
}
