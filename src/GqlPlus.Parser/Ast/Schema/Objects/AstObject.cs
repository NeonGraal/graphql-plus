﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObject<TObjBase, TObjField, TObjAlt>(
  ITokenAt At,
  string Name,
  string Description
) : AstType<IGqlpObjBase>(At, Name, Description)
  , IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjBase : IGqlpObjBase
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
{
  public IGqlpTypeParam[] TypeParams { get; set; } = [];
  public TObjField[] ObjFields { get; set; } = [];
  public TObjAlt[] ObjAlternates { get; set; } = [];

  IEnumerable<IGqlpTypeParam> IGqlpObject.TypeParams => TypeParams;
  IEnumerable<IGqlpObjField> IGqlpObject.Fields => ObjFields.Cast<IGqlpObjField>();
  IEnumerable<IGqlpObjAlternate> IGqlpObject.Alternates => ObjAlternates.Cast<IGqlpObjAlternate>();

  TObjBase? IGqlpObject<TObjBase>.ObjParent => Parent is TObjBase objBase ? objBase : default;
  IEnumerable<TObjField> IGqlpObject<TObjBase, TObjField, TObjAlt>.ObjFields => ObjFields;
  IEnumerable<TObjAlt> IGqlpObject<TObjBase, TObjField, TObjAlt>.ObjAlternates => ObjAlternates;

  public virtual bool Equals(AstObject<TObjBase, TObjField, TObjAlt>? other)
    => other is IGqlpObject<TObjBase, TObjField, TObjAlt> obj && Equals(obj);
  public bool Equals(IGqlpObject<TObjBase, TObjField, TObjAlt>? other)
    => base.Equals(other)
      && TypeParams.SequenceEqual(other.TypeParams)
      && ObjFields.SequenceEqual(other.ObjFields)
      && ObjAlternates.SequenceEqual(other.ObjAlternates);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), TypeParams.Length, ObjFields.Length, ObjAlternates.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(TypeParams.Bracket("<", ">"))
      .Concat(Parent.Bracket(":", ""))
      .Concat(ObjFields.Bracket("{", "}"))
      .Concat(ObjAlternates.Bracket("|"));
}
