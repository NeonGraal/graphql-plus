using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObject<TObjBase, TObjField, TObjAlt>(
  TokenAt At,
  string Name,
  string Description
) : AstType<IGqlpObjBase>(At, Name, Description)
  , IEquatable<AstObject<TObjBase, TObjField, TObjAlt>>
  , IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjBase : IGqlpObjBase
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
{
  public IGqlpTypeParameter[] TypeParameters { get; set; } = [];
  public TObjField[] ObjFields { get; set; } = [];
  public TObjAlt[] ObjAlternates { get; set; } = [];

  IEnumerable<IGqlpTypeParameter> IGqlpObject.TypeParameters => TypeParameters;
  IEnumerable<IGqlpObjField> IGqlpObject.Fields => ObjFields.Cast<IGqlpObjField>();
  IEnumerable<IGqlpObjAlternate> IGqlpObject.Alternates => ObjAlternates.Cast<IGqlpObjAlternate>();

  TObjBase? IGqlpObject<TObjBase, TObjField, TObjAlt>.ObjParent => Parent is TObjBase objBase ? objBase : default;
  IEnumerable<TObjField> IGqlpObject<TObjBase, TObjField, TObjAlt>.ObjFields => ObjFields;
  IEnumerable<TObjAlt> IGqlpObject<TObjBase, TObjField, TObjAlt>.ObjAlternates => ObjAlternates;

  public virtual bool Equals(AstObject<TObjBase, TObjField, TObjAlt>? other)
    => base.Equals(other)
      && TypeParameters.SequenceEqual(other.TypeParameters)
      && ObjFields.SequenceEqual(other.ObjFields)
      && ObjAlternates.SequenceEqual(other.ObjAlternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), TypeParameters.Length, ObjFields.Length, ObjAlternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeParameters.Bracket("<", ">"))
      .Concat(Parent.Bracket(":", ""))
      .Concat(ObjFields.Bracket("{", "}"))
      .Concat(ObjAlternates.Bracket("|"));
}
