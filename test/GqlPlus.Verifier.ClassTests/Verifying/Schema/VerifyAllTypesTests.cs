using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifyAllTypesTests
  : VerifierTestsBase
{
  private readonly ForVU<IGqlpObject<IGqlpDualField>> _dualAllTypes = new();
  private readonly ForVU<IGqlpEnum> _enumAllTypes = new();
  private readonly ForVU<IGqlpObject<IGqlpInputField>> _inputAllTypes = new();
  private readonly ForVU<IGqlpObject<IGqlpOutputField>> _outputAllTypes = new();
  private readonly ForVU<IGqlpDomain> _domainAllTypes = new();
  private readonly ForVU<IGqlpUnion> _unionAllTypes = new();
  private readonly VerifyAllTypes _verifier;

  public VerifyAllTypesTests()
  {
    VerifierRepo.UsageFor<IGqlpObject<IGqlpDualField>>().Returns(_dualAllTypes.Intf);
    VerifierRepo.UsageFor<IGqlpEnum>().Returns(_enumAllTypes.Intf);
    VerifierRepo.UsageFor<IGqlpObject<IGqlpInputField>>().Returns(_inputAllTypes.Intf);
    VerifierRepo.UsageFor<IGqlpObject<IGqlpOutputField>>().Returns(_outputAllTypes.Intf);
    VerifierRepo.UsageFor<IGqlpDomain>().Returns(_domainAllTypes.Intf);
    VerifierRepo.UsageFor<IGqlpUnion>().Returns(_unionAllTypes.Intf);
    _verifier = new(VerifierRepo);
  }

  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    IAstType item1 = A.Error<IAstType>();
    IAstType item2 = A.Error<IAstType>();

    _verifier.Verify([item1, item2], Errors);

    _verifier.ShouldSatisfyAllConditions(
      _dualAllTypes.Called,
      _enumAllTypes.Called,
      _inputAllTypes.Called,
      _outputAllTypes.Called,
      _domainAllTypes.Called,
      _unionAllTypes.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Schema_WithNoDeclarations_ReturnsNoErrors()
  {
    _verifier.Verify([], Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Schema_WithAliasedDeclarations_ReturnsNoErrors()
  {
    IAstType type = A.Enum("Enum").WithLabels(["Alias"]).AsEnum;

    _verifier.Verify([type], Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Schema_WithAliasDuplicates_ReturnsError()
  {
    IAstType type1 = A.Enum("Enum").WithLabels(["Alias"]).AsEnum;

    IAstType type2 = A.Union("Union").WithMembers(["Alias"]).AsUnion;

    _verifier.Verify([type1, type2], Errors);

    Errors.ShouldBeEmpty();
  }
}
