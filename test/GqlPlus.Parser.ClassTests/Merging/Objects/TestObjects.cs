using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

public abstract class TestObjects<TObject, TObjectAst, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase>
  : TestTyped<IGqlpType, TObject, TObjBase, TObjField>
  where TObject : IGqlpObject<TObjField, TObjAlt, TObjBase>
  where TObjectAst : AstObject<TObjField, TObjAlt, TObjBase>, TObject
  where TObjField : IGqlpObjField<TObjBase>, IGqlpDescribed
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate<TObjBase>, IGqlpDescribed
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsTypeParametersCantMerge_ReturnsErrors(string name, string[] typeParameters)
    => this
      .SkipUnless(typeParameters)
      .CanMergeReturnsError(TypeParameters)
      .CanMerge_Errors(
        MakeObject(name) with { TypeParameters = typeParameters.ThrowIfNull().TypeParameters() },
        MakeObject(name) with { TypeParameters = typeParameters.ThrowIfNull().TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsAlternatesCantMerge_ReturnsErrors(string name, AlternateInput[] alternates)
    => this
      .CanMergeReturnsError(Alternates)
      .CanMerge_Errors(
        MakeObject(name) with { Alternates = MakeAlternates(alternates) },
        MakeObject(name) with { Alternates = MakeAlternates(alternates) });

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsFieldsCantMerge_ReturnsErrors(string name, FieldInput[] fields)
    => this
      .CanMergeReturnsError(Fields)
      .CanMerge_Errors(
        MakeObject(name) with { Fields = MakeFields(fields) },
        MakeObject(name) with { Fields = MakeFields(fields) });

  protected IMerge<IGqlpTypeParameter> TypeParameters { get; }
  protected IMerge<TObjAlt> Alternates { get; }
  protected IMerge<TObjField> Fields { get; }

  protected TestObjects()
  {
    TypeParameters = Merger<IGqlpTypeParameter>();
    Alternates = Merger<TObjAlt>();
    Fields = Merger<TObjField>();
  }

  internal abstract AstObjectsMerger<TObject, TObjField, TObjAlt, TObjBase> MergerObject { get; }
  internal override AstTypeMerger<IGqlpType, TObject, TObjBase, TObjField> MergerTyped => MergerObject;

  protected abstract TObjectAst MakeObject(string name, string[]? aliases = null, string description = "", TObjBase? parent = default);
  protected abstract TObjFieldAst[] MakeFields(FieldInput[] fields);
  protected abstract TObjAltAst[] MakeAlternates(AlternateInput[] alternates);
  protected abstract TObjBase MakeBase(string type);

  protected override TObject MakeTyped(string name, string[]? aliases = null, string description = "", TObjBase? parent = default)
    => MakeObject(name, aliases, description, parent);
  protected override TObjBase MakeParent(string parent)
    => MakeBase(parent);
}
