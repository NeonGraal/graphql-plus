using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public abstract class TestObjects<TObject, TField, TReference>
  : TestTyped<AstType, TObject, TReference, TField>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsTypeParametersCantMerge_ReturnsFalse(string name, string[] typeParameters)
  {
    TypeParameters.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      MakeObject(name) with { TypeParameters = typeParameters.TypeParameters() },
      MakeObject(name) with { TypeParameters = typeParameters.TypeParameters() }],
      typeParameters.Length < 2);
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsAlternatesCantMerge_ReturnsFalse(string name, string[] alternates)
  {
    Alternates.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      MakeObject(name) with { Alternates = alternates.Alternates(MakeReference) },
      MakeObject(name) with { Alternates = alternates.Alternates(MakeReference) }]);
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsFieldsCantMerge_ReturnsFalse(string name, FieldInput[] fields)
  {
    Fields.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      MakeObject(name) with { Fields = MakeFields(fields) },
      MakeObject(name) with { Fields = MakeFields(fields) }]);
  }

  protected readonly IMerge<TypeParameterAst> TypeParameters;
  protected readonly IMerge<AstAlternate<TReference>> Alternates;
  protected readonly IMerge<TField> Fields;

  protected TestObjects()
  {
    TypeParameters = Merger<TypeParameterAst>();
    Alternates = Merger<AstAlternate<TReference>>();
    Fields = Merger<TField>();
  }

  internal abstract AstObjectsMerger<TObject, TField, TReference> MergerObject { get; }
  internal override AstTypeMerger<AstType, TObject, TReference, TField> MergerTyped => MergerObject;

  protected abstract TObject MakeObject(string name, string description = "");
  protected abstract TField[] MakeFields(FieldInput[] fields);
  protected abstract TReference MakeReference(string type);

  protected override TObject MakeTyped(string name, string description = "")
    => MakeObject(name, description);
  protected override TReference MakeParent(string parent)
    => MakeReference(parent);
}
