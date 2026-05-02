using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifyAllTypesTests
  : VerifierTestsBase
{
  private readonly ForVU<IAstObject<IAstDualField>> _dualAllTypes = new();
  private readonly ForVU<IAstEnum> _enumAllTypes = new();
  private readonly ForVU<IAstObject<IAstInputField>> _inputAllTypes = new();
  private readonly ForVU<IAstObject<IAstOutputField>> _outputAllTypes = new();
  private readonly ForVU<IAstDomain> _domainAllTypes = new();
  private readonly ForVU<IAstUnion> _unionAllTypes = new();
  private readonly VerifyAllTypes _verifier;

  public VerifyAllTypesTests()
  {
    UsageForReturns(_dualAllTypes.Intf);
    UsageForReturns(_enumAllTypes.Intf);
    UsageForReturns(_inputAllTypes.Intf);
    UsageForReturns(_outputAllTypes.Intf);
    UsageForReturns(_domainAllTypes.Intf);
    UsageForReturns(_unionAllTypes.Intf);
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
