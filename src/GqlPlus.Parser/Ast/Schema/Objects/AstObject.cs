using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObject<TObjField>(
  ITokenAt At,
  string Name,
  string Description
) : AstType<IGqlpObjBase>(At, Name, Description)
  , IGqlpObject<TObjField>
  where TObjField : IGqlpObjField
{
  public IGqlpTypeParam[] TypeParams { get; set; } = [];
  public TObjField[] ObjFields { get; set; } = [];
  public IGqlpObjAlt[] Alternates { get; set; } = [];

  IEnumerable<IGqlpTypeParam> IGqlpObject.TypeParams => TypeParams;
  IEnumerable<IGqlpObjField> IGqlpObject.Fields => ObjFields.Cast<IGqlpObjField>();
  IEnumerable<IGqlpObjAlt> IGqlpObject.Alternates => Alternates;

  IEnumerable<TObjField> IGqlpObject<TObjField>.ObjFields => ObjFields;

  public virtual bool Equals(AstObject<TObjField>? other)
    => other is IGqlpObject<TObjField> obj && Equals(obj);
  public bool Equals(IGqlpObject<TObjField>? other)
    => base.Equals(other)
      && TypeParams.SequenceEqual(other.TypeParams)
      && ObjFields.SequenceEqual(other.ObjFields)
      && Alternates.SequenceEqual(other.Alternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), TypeParams.Length, ObjFields.Length, Alternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeParams.Bracket("<", ">"))
      .Concat(Parent.Bracket(":", ""))
      .Concat(ObjFields.Bracket("{", "}"))
      .Concat(Alternates.Bracket("|"));
}
