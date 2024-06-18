using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public abstract record class AstObject<TObjField, TObjAlt, TObjBase>(
  TokenAt At,
  string Name,
  string Description
) : AstType<TObjBase>(At, Name, Description)
  , IEquatable<AstObject<TObjField, TObjAlt, TObjBase>>
  , IGqlpObject<TObjField, TObjAlt, TObjBase>
  where TObjField : IGqlpObjField<TObjBase>
  where TObjAlt : IGqlpObjAlternate<TObjBase>
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
{
  public TypeParameterAst[] TypeParameters { get; set; } = [];
  public TObjField[] Fields { get; set; } = [];
  public TObjAlt[] Alternates { get; set; } = [];

  IEnumerable<IGqlpTypeParameter> IGqlpObject.TypeParameters => TypeParameters;
  IEnumerable<TObjField> IGqlpObject<TObjField, TObjAlt, TObjBase>.Fields => Fields;
  IEnumerable<TObjAlt> IGqlpObject<TObjField, TObjAlt, TObjBase>.Alternates => Alternates;

  public virtual bool Equals(AstObject<TObjField, TObjAlt, TObjBase>? other)
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
