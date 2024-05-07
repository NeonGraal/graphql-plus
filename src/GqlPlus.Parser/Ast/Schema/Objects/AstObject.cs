using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public abstract record class AstObject<TObjField, TObjBase>(
  TokenAt At,
  string Name,
  string Description
) : AstType<TObjBase>(At, Name, Description)
  , IEquatable<AstObject<TObjField, TObjBase>>
  , IAstObject
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>, IEquatable<TObjBase>
{
  public TypeParameterAst[] TypeParameters { get; set; } = [];
  public TObjField[] Fields { get; set; } = [];
  public AstAlternate<TObjBase>[] Alternates { get; set; } = [];

  public virtual bool Equals(AstObject<TObjField, TObjBase>? other)
    => base.Equals(other)
      && TypeParameters.SequenceEqual(other.TypeParameters)
      && Fields.SequenceEqual(other.Fields)
      && Alternates.SequenceEqual(other.Alternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), TypeParameters.Length, Fields.Length, Alternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeParameters.Bracket("<", ">"))
      .Concat(Parent.Bracket(":", ""))
      .Concat(Fields.Bracket("{", "}"))
      .Concat(Alternates.Bracket("|"));
}

public interface IAstObject
  : IGqlpType
{
  TypeParameterAst[] TypeParameters { get; }
}
