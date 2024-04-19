using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestObjects<TObject, TField, TRef>
  : TestTyped<AstType, TObject, TRef, TField>
  where TObject : AstObject<TField, TRef>
  where TField : AstField<TRef>, IAstDescribed
  where TRef : AstReference<TRef>
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
        MakeObject(name) with { Alternates = alternates.Alternates(MakeReference) },
        MakeObject(name) with { Alternates = alternates.Alternates(MakeReference) });

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsFieldsCantMerge_ReturnsErrors(string name, FieldInput[] fields)
    => this
      .CanMergeReturnsError(Fields)
      .CanMerge_Errors(
        MakeObject(name) with { Fields = MakeFields(fields) },
        MakeObject(name) with { Fields = MakeFields(fields) });

  protected IMerge<TypeParameterAst> TypeParameters { get; }
  protected IMerge<AstAlternate<TRef>> Alternates { get; }
  protected IMerge<TField> Fields { get; }

  protected TestObjects()
  {
    TypeParameters = Merger<TypeParameterAst>();
    Alternates = Merger<AstAlternate<TRef>>();
    Fields = Merger<TField>();
  }

  internal abstract AstObjectsMerger<TObject, TField, TRef> MergerObject { get; }
  internal override AstTypeMerger<AstType, TObject, TRef, TField> MergerTyped => MergerObject;

  protected abstract TObject MakeObject(string name, string description = "");
  protected abstract TField[] MakeFields(FieldInput[] fields);
  protected abstract TRef MakeReference(string type);

  protected override TObject MakeTyped(string name, string description = "")
    => MakeObject(name, description);
  protected override TRef MakeParent(string parent)
    => MakeReference(parent);
}
