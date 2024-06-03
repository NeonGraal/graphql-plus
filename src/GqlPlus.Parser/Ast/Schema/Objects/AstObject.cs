using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public abstract record class AstObject<TObjField, TObjBase>(
  TokenAt At,
  string Name,
  string Description
) : AstType<TObjBase>(At, Name, Description)
  , IEquatable<AstObject<TObjField, TObjBase>>
  , IGqlpObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>, IGqlpObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>, IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{
  public TypeParameterAst[] TypeParameters { get; set; } = [];
  public TObjField[] Fields { get; set; } = [];
  public AstAlternate<TObjBase>[] Alternates { get; set; } = [];
  IEnumerable<IGqlpTypeParameter> IGqlpObject.TypeParameters => TypeParameters;
  IEnumerable<TObjField> IGqlpObject<TObjField, TObjBase>.Fields => Fields;
  IEnumerable<IGqlpAlternate<TObjBase>> IGqlpObject<TObjField, TObjBase>.Alternates => Alternates;

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
