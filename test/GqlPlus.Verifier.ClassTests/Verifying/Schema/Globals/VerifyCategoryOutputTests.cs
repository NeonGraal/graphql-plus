namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyCategoryOutputTests
  : UsageVerifierTestsBase<IGqlpSchemaCategory>
{
  private readonly VerifyCategoryOutput _verifier;
  private readonly IGqlpSchemaCategory _category;

  protected override IGqlpSchemaCategory TheUsage => _category;
  protected override IVerifyUsage<IGqlpSchemaCategory> Verifier => _verifier;

  public VerifyCategoryOutputTests()
  {
    _verifier = new(Aliased.Intf);

    IGqlpTypeRef output = A.Named<IGqlpTypeRef>("Type");

    _category = A.Error<IGqlpSchemaCategory>();
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
    Define<IGqlpObject<IGqlpOutputField>>("Type");

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_WithAliases_ReturnsNoError()
  {
    Define<IGqlpObject<IGqlpOutputField>>("Type");
    _category.Aliases.Returns(["Alias1", "Alias2"]);
    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_DefinedGenericOutput_ReturnsError()
  {
    IGqlpObject<IGqlpOutputField> outputType = A.Named<IGqlpObject<IGqlpOutputField>>("Type");
    IGqlpTypeParam typeParam = A.TypeParam("a", "b");
    outputType.TypeParams.Returns([typeParam]);
    Definitions.Add(outputType);

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_DefinedInput_ReturnsError()
  {
    Define<IGqlpObject<IGqlpInputField>>("Type");

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
