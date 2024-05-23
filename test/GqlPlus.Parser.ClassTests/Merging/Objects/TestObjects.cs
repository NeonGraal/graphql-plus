using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

public abstract class TestObjects<TObject, TObjField, TObjBase>
  : TestTyped<IGqlpType, TObject, TObjBase, TObjField>
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>, IGqlpDescribed
  where TObjBase : AstObjectBase<TObjBase>
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
  public void CanMerge_TwoAstsAlternatesCantMerge_ReturnsErrors(string name, string[] alternates)
    => this
      .CanMergeReturnsError(Alternates)
      .CanMerge_Errors(
        MakeObject(name) with { Alternates = alternates.Alternates(MakeBase) },
        MakeObject(name) with { Alternates = alternates.Alternates(MakeBase) });

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsFieldsCantMerge_ReturnsErrors(string name, FieldInput[] fields)
    => this
      .CanMergeReturnsError(Fields)
      .CanMerge_Errors(
        MakeObject(name) with { Fields = MakeFields(fields) },
        MakeObject(name) with { Fields = MakeFields(fields) });

  protected IMerge<IGqlpTypeParameter> TypeParameters { get; }
  protected IMerge<AstAlternate<TObjBase>> Alternates { get; }
  protected IMerge<TObjField> Fields { get; }

  protected TestObjects()
  {
    TypeParameters = Merger<IGqlpTypeParameter>();
    Alternates = Merger<AstAlternate<TObjBase>>();
    Fields = Merger<TObjField>();
  }

  internal abstract AstObjectsMerger<TObject, TObjField, TObjBase> MergerObject { get; }
  internal override AstTypeMerger<IGqlpType, TObject, TObjBase, TObjField> MergerTyped => MergerObject;

  protected abstract TObject MakeObject(string name, string[]? aliases = null, string description = "", TObjBase? parent = default);
  protected abstract TObjField[] MakeFields(FieldInput[] fields);
  protected abstract TObjBase MakeBase(string type);

  protected override TObject MakeTyped(string name, string[]? aliases = null, string description = "", TObjBase? parent = default)
    => MakeObject(name, aliases, description, parent);
  protected override TObjBase MakeParent(string parent)
    => MakeBase(parent);
}
