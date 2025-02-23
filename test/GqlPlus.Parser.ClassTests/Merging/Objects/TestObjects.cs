﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

public abstract class TestObjects<TObject, TObjBase, TObjField, TObjAlt>
  : TestTyped<IGqlpType, TObject, IGqlpObjBase, TObjField>
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{
  [SkippableTheory, RepeatData]
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

  protected TestObjects()
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
