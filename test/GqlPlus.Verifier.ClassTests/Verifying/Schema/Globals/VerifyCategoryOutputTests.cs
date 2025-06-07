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
    Define<IGqlpOutputObject>("Type");

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_WithAliases_ReturnsNoError()
  {
    Define<IGqlpOutputObject>("Type");
    _category.Aliases.Returns(["Alias1", "Alias2"]);
    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_DefinedGenericOutput_ReturnsError()
  {
    IGqlpOutputObject outputType = A.Named<IGqlpOutputObject>("Type");
    IGqlpTypeParam[] typeParams = [A.Error<IGqlpTypeParam>()];
    outputType.TypeParams.Returns(typeParams);
    Definitions.Add(outputType);

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_DefinedInput_ReturnsError()
  {
    Define<IGqlpInputObject>("Type");

    Usages.Add(_category);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
