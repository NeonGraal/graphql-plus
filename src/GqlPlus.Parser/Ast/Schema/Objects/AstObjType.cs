namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjType(
  ITokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IAstObjType
{
  public bool IsTypeParam { get; set; }

  public string TypeName => IsTypeParam ? Name.Prefixed("$") : Name;

  public virtual string FullType => TypeName;

  public virtual bool Equals(AstObjType? other)
    => other is IAstObjType objType && Equals(objType);
  public bool Equals(IAstObjType? other)
    => base.Equals(other)
    && IsTypeParam == other.IsTypeParam;
  public override int GetHashCode()
  => HashCode.Combine(base.GetHashCode(), IsTypeParam);

  internal override IEnumerable<string?> GetFields()
    => DescriptionAt.Append(TypeName);
}
