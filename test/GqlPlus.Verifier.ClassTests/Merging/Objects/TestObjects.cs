﻿using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging;

public abstract class TestObjects<TObject, TObjField, TObjBase>
  : TestTyped<AstType, TObject, TObjBase, TObjField>
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>, IAstDescribed
  where TObjBase : AstObjectBase<TObjBase>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsTypeParametersCantMerge_ReturnsErrors(string name, string[] typeParameters)
    => this
      .SkipUnless(typeParameters)
      .CanMergeReturnsError(TypeParameters)
      .CanMerge_Errors(
        MakeObject(name) with { TypeParameters = typeParameters!.TypeParameters() },
        MakeObject(name) with { TypeParameters = typeParameters!.TypeParameters() });

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

  protected IMerge<TypeParameterAst> TypeParameters { get; }
  protected IMerge<AstAlternate<TObjBase>> Alternates { get; }
  protected IMerge<TObjField> Fields { get; }

  protected TestObjects()
  {
    TypeParameters = Merger<TypeParameterAst>();
    Alternates = Merger<AstAlternate<TObjBase>>();
    Fields = Merger<TObjField>();
  }

  internal abstract AstObjectsMerger<TObject, TObjField, TObjBase> MergerObject { get; }
  internal override AstTypeMerger<AstType, TObject, TObjBase, TObjField> MergerTyped => MergerObject;

  protected abstract TObject MakeObject(string name, string description = "");
  protected abstract TObjField[] MakeFields(FieldInput[] fields);
  protected abstract TObjBase MakeBase(string type);

  protected override TObject MakeTyped(string name, string description = "")
    => MakeObject(name, description);
  protected override TObjBase MakeParent(string parent)
    => MakeBase(parent);
}
