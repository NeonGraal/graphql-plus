using GqlPlus.Building.Schema.Objects;
using GqlPlus.Matching;

namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectVerifierTestsBase<TObjField>
  : UsageVerifierTestsBase<IGqlpObject<TObjField>>
  where TObjField : class, IGqlpObjField
{
  internal readonly ForM<TObjField> MergeFields = new();
  internal readonly ForM<IGqlpAlternate> MergeAlternates = new();
  protected TypeKind Kind { get; }
  internal ObjectVerifierParams<TObjField> Verifiers { get; }

  protected ObjectVerifierTestsBase(TypeKind kind)
  {
    Kind = kind;

    ArgMatcher = A.Of<Matcher<IGqlpTypeArg>.I>();

    ArgDelegate = A.Of<Matcher<IGqlpTypeArg>.D>();
    ArgDelegate().Returns(ArgMatcher);

    Verifiers = new(
      Aliased.Intf,
      MergeFields.Intf,
      MergeAlternates.Intf,
      ArgDelegate,
      new FieldObjectKind<TObjField>(kind));

    TheBuilder = new(kind.ToString(), kind);
  }

  protected Matcher<IGqlpTypeArg>.I ArgMatcher { get; }
  protected Matcher<IGqlpTypeArg>.D ArgDelegate { get; }

  protected sealed override IGqlpObject<TObjField> TheUsage => TheObject;

  protected ObjectBuilder<TObjField> TheBuilder { get; }
  protected IGqlpObject<TObjField> TheObject => _theObject ??= TheBuilder.AsObject;
  private IGqlpObject<TObjField>? _theObject;

  [Fact]
  public void Verify_CallsMergeFieldsAndAlternates_WithoutErrors()
  {
    Verifier.Verify(UsageAliased, Errors);

    Verifier.ShouldSatisfyAllConditions(
      MergeFields.NotCalled,
      MergeAlternates.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_WithBasic_ReturnsNoErrors()
    => Verify_NoErrors();

  [Theory, RepeatData]
  public void Verify_WithParent_ReturnsNoErrors(string parentName)
  {
    DefineObject(parentName);

    TheBuilder.WithParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithParentSame_ReturnsErrors(string name)
  {
    TheBuilder.WithParent(name);

    Verify_Errors("cannot be a child of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithParentSameRecurse_ReturnsErrors(string name, string parentName)
  {
    this.SkipEqual(parentName, name);

    DefineObject(parentName, o => o.WithParent(name));

    TheBuilder.WithParent(parentName);

    Verify_Errors("cannot be a child of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithWrongParamParent_ReturnsErrors(string parentName, string constraint)
  {
    Define(A.DomainString(constraint));

    TheBuilder
      .WithTypeParam(parentName, constraint)
      .WithParent(parentName, t => t.IsTypeParam());

    Verify_Errors("Invalid Kind for");
  }

  [Theory, RepeatData]
  public void Verify_WithTypeParams_ReturnsNoErrors(string paramName, string constraint)
  {
    DefineObject(constraint);

    TheBuilder
      .WithTypeParam(paramName, constraint)
      .WithParent(paramName, t => t.IsTypeParam());

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithTypeParamsNoConstraint_ReturnsError(string typeParam)
  {
    TheBuilder.WithTypeParam(typeParam, "");

    TheBuilder.WithParent(typeParam, t => t.IsTypeParam());

    Verify_Errors("not defined");
  }

  protected void Verify_NoErrors()
  {
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  protected void Verify_Errors(string message, string name = "")
  {
    TheObject.Name.Returns(name.IfWhiteSpace("Object"));
    Usages.Add(TheObject);
    Definitions.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldSatisfyAllConditions(
      e => e.ShouldNotBeEmpty(),
      e => e.ShouldContain(m => m.Message.Contains(message), string.Join('\n', Errors.Select(m => " - " + m.Message))));
  }

  protected void DefineObject(string name, Action<ObjectBuilder<TObjField>>? config = null)
  {
    ObjectBuilder<TObjField> builder = A.Obj<TObjField>(Kind, name);
    config?.Invoke(builder);
    IGqlpObject<TObjField> obj = builder.AsObject;
    Definitions.Add(obj);
    Usages.Add(obj);
  }
}
