using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public abstract class TestObjects<TObject, TField, TReference>
  : TestTyped<AstType, TObject, TReference>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsTypeParametersCantMerge_ReturnsFalse(string name, string[] typeParameters)
  {
    TypeParameters.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      MakeObject(name) with { TypeParameters = typeParameters.TypeParameters() },
      MakeObject(name)],
      typeParameters.Length < 2);
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsAlternatesCantMerge_ReturnsFalse(string name, string alternate)
  {
    Alternates.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      MakeObject(name) with { Alternates = alternate.Alternates(MakeReference) },
      MakeObject(name)]);
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsFieldsCantMerge_ReturnsFalse(string name, string field, string type)
  {
    Fields.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      MakeObject(name) with { Fields = MakeFields(field, type) },
      MakeObject(name)]);
  }

  protected readonly IMerge<TypeParameterAst> TypeParameters;
  protected readonly IMerge<AlternateAst<TReference>> Alternates;
  protected readonly IMerge<TField> Fields;

  protected TestObjects()
  {
    TypeParameters = Merger<TypeParameterAst>();
    Alternates = Merger<AlternateAst<TReference>>();
    Fields = Merger<TField>();
  }

  internal abstract ObjectsMerger<TObject, TField, TReference> MergerObject { get; }
  internal override TypedMerger<AstType, TObject, TReference> MergerTyped => MergerObject;

  protected abstract TObject MakeObject(string name, string description = "");
  protected abstract TField[] MakeFields(string field, string type);
  protected abstract TReference MakeReference(string type);

  protected override TObject MakeTyped(string name, string description = "")
    => MakeObject(name, description);
  protected override TReference MakeParent(string parent)
    => MakeReference(parent);
}
