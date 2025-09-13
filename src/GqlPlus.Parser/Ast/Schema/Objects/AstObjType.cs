using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract record class AstObjType(
  ITokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IGqlpObjType
{
  public bool IsTypeParam { get; set; }

  public abstract string Label { get; }

  public string TypeName => IsTypeParam ? Name.Prefixed("$") : Name;

  public virtual string FullType => TypeName;

  public virtual bool Equals(AstObjType? other)
    => other is IGqlpObjType objType && Equals(objType);
  public bool Equals(IGqlpObjType? other)
    => base.Equals(other)
    && IsTypeParam == other!.IsTypeParam;
  public override int GetHashCode()
  => HashCode.Combine(base.GetHashCode(), IsTypeParam);

  internal override IEnumerable<string?> GetFields()
    => [Description.Quoted("'"), At.ToString(), TypeName];
}
