namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveInputTests
  : UsageVerifierTestsBase<IGqlpSchemaDirective>
{
  private readonly VerifyDirectiveInput _verifier;
  private readonly IGqlpSchemaDirective _directive;

  protected override IGqlpSchemaDirective TheUsage => _directive;
  protected override IVerifyUsage<IGqlpSchemaDirective> Verifier => _verifier;

  public VerifyDirectiveInputTests()
  {
    _verifier = new(Aliased.Intf);

    IGqlpInputParam input = EFor<IGqlpInputParam>();
    IGqlpInputBase type = NFor<IGqlpInputBase>("Type");
    input.Type.Returns(type);

    _directive = EFor<IGqlpSchemaDirective>();
    _directive.Params.Returns([input]);
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
    Define<IGqlpInputObject>("Type");

    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_WithAliases_ReturnsNoError()
  {
    Define<IGqlpInputObject>("Type");

    _directive.Aliases.Returns(["Alias1", "Alias2"]);
    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_DefinedOutput_ReturnsError()
  {
    Define<IGqlpOutputObject>("Type");

    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
