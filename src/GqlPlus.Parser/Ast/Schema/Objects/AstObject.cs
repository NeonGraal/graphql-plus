using GqlPlus;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal record class AstObject<TObjField>
  : AstType<IAstObjBase>
  , IAstObject<TObjField>
  where TObjField : IAstObjField
{
  internal AstObject(
    TypeKind kind,
    ITokenAt at,
    string name,
    string description
  ) : base(at, name, description)
    => Kind = kind;

  public IAstTypeParam[] TypeParams { get; set; } = [];
  public TObjField[] ObjFields { get; set; } = [];
  public IAstAlternate[] Alternates { get; set; } = [];

  public override TypeKind Kind { get; }

  IEnumerable<IAstTypeParam> IAstObject.TypeParams => TypeParams;
  IEnumerable<IAstObjField> IAstObject.Fields => ObjFields.Cast<IAstObjField>();
  IEnumerable<IAstAlternate> IAstObject.Alternates => Alternates;

  IEnumerable<TObjField> IAstObject<TObjField>.ObjFields => ObjFields;

  public virtual bool Equals(AstObject<TObjField>? other)
    => other is IAstObject<TObjField> obj && Equals(obj);
  public bool Equals(IAstObject<TObjField>? other)
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
