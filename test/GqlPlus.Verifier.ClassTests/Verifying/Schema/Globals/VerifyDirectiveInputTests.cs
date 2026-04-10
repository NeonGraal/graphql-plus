namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveInputTests
  : UsageVerifierTestsBase<IAstSchemaDirective>
{
  private readonly VerifyDirectiveInput _verifier;
  private readonly IAstSchemaDirective _directive;

  protected override IAstSchemaDirective TheUsage => _directive;
  protected override IVerifyUsage<IAstSchemaDirective> Verifier => _verifier;

  public VerifyDirectiveInputTests()
  {
    _verifier = new(VerifierRepo);

    IAstInputParam input = A.InputParam("Type").AsInputParam;

    _directive = A.Error<IAstSchemaDirective>();
    _directive.Parameter.Returns(input);
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
  public void Verify_UndefinedInput_ReturnsError()
  {
    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_DefinedInput_ReturnsNoError()
  {
    Define<IAstObject<IAstInputField>>("Type");

    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_WithAliases_ReturnsNoError()
  {
    Define<IAstObject<IAstInputField>>("Type");

    _directive.Aliases.Returns(["Alias1", "Alias2"]);
    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_DefinedOutput_ReturnsError()
  {
    Define<IAstObject<IAstOutputField>>("Type");

    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
