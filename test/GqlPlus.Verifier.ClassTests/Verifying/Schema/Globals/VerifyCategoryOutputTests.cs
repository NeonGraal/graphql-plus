namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyCategoryOutputTests
  : UsageVerifierTestsBase<IAstSchemaCategory>
{
  private readonly VerifyCategoryOutput _verifier;
  private readonly IAstSchemaCategory _category;

  protected override IAstSchemaCategory TheUsage => _category;
  protected override IVerifyUsage<IAstSchemaCategory> Verifier => _verifier;

  public VerifyCategoryOutputTests()
  {
    _verifier = new(VerifierRepo);

    IAstTypeRef output = A.Named<IAstTypeRef>("Type");

    _category = A.Error<IAstSchemaCategory>();
    _category.Output.Returns(output);
  }

  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_UndefinedOutput_ReturnsError()
  {
    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_DefinedOutput_ReturnsNoError()
  {
    Define<IAstObject<IAstOutputField>>("Type");

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_WithAliases_ReturnsNoError()
  {
    Define<IAstObject<IAstOutputField>>("Type");
    _category.Aliases.Returns(["Alias1", "Alias2"]);
    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_DefinedGenericOutput_ReturnsError()
  {
    IAstObject<IAstOutputField> outputType = A.Named<IAstObject<IAstOutputField>>("Type");
    IAstTypeParam typeParam = A.TypeParam("a", "b");
    outputType.TypeParams.Returns([typeParam]);
    Definitions.Add(outputType);

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_DefinedInput_ReturnsError()
  {
    Define<IAstObject<IAstInputField>>("Type");

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
