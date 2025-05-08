﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Merging.Objects;
using GqlPlus.Merging.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class TestObjectAsts<TObject, TObjBase, TObjField, TObjAlt>
  : TestTypedAsts<IGqlpType, TObject, IGqlpObjBase, TObjField>
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsTypeParamsCantMerge_ReturnsErrors(string name, string[] typeParams)
    => this
      .SkipUnless(typeParams)
      .CanMergeReturnsError(TypeParams)
      .CanMerge_Errors(
        MakeObject(name, typeParams: typeParams),
        MakeObject(name, typeParams: typeParams));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsAlternatesCantMerge_ReturnsErrors(string name, AlternateInput[] alternates)
    => this
      .CanMergeReturnsError(Alternates)
      .CanMerge_Errors(
        MakeObject(name, alternates: alternates),
        MakeObject(name, alternates: alternates));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsFieldsCantMerge_ReturnsErrors(string name, FieldInput[] fields)
    => this
      .CanMergeReturnsError(Fields)
      .CanMerge_Errors(
        MakeObject(name, fields: fields),
        MakeObject(name, fields: fields));

  protected IMerge<IGqlpTypeParam> TypeParams { get; }
  protected IMerge<TObjAlt> Alternates { get; }
  protected IMerge<TObjField> Fields { get; }

  protected TestObjectAsts()
  {
    TypeParams = Merger<IGqlpTypeParam>();
    Alternates = Merger<TObjAlt>();
    Fields = Merger<TObjField>();
  }

  internal abstract AstObjectsMerger<TObject, TObjBase, TObjField, TObjAlt> MergerObject { get; }
  internal override AstTypeMerger<IGqlpType, TObject, IGqlpObjBase, TObjField> MergerTyped => MergerObject;

  protected abstract TObject MakeObject(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpObjBase? parent = default,
    string[]? typeParams = null,
    FieldInput[]? fields = null,
    AlternateInput[]? alternates = null);
  protected abstract TObjBase MakeBase(string type);

  protected override TObject MakeTyped(string name, string[]? aliases = null, string description = "", IGqlpObjBase? parent = default)
    => MakeObject(name, aliases, description, parent);
  protected override IGqlpObjBase MakeParent(string parent)
    => MakeBase(parent);
}
