using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public abstract class TestObjects<TObject, TField, TReference>
  : TestAliased<TObject>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameBaseType_ReturnsTrue(string name, string type)
    => CanMerge_True([
      MakeObject(name) with { Parent = MakeReference(type) },
      MakeObject(name) with { Parent = MakeReference(type) }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentTypes_ReturnsFalse(string name, string type1, string type2)
    => CanMerge_False([
      MakeObject(name) with { Parent = MakeReference(type1) },
      MakeObject(name) with { Parent = MakeReference(type2) }],
      type1 == type2);

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
  internal override GroupsMerger<TObject> MergerGroups => MergerObject;

  protected abstract TObject MakeObject(string name, string description = "");
  protected abstract TField[] MakeFields(string field, string type);
  protected abstract TReference MakeReference(string type);
  protected override TObject MakeAliased(string name, string[] aliases, string description = "")
    => MakeObject(name, description) with { Aliases = aliases };

}
