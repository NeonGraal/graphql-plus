﻿namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifyAllTypesTests
  : VerifierTestsBase
{
  private readonly ForVU<IGqlpDualObject> _dualAllTypes = new();
  private readonly ForVU<IGqlpEnum> _enumAllTypes = new();
  private readonly ForVU<IGqlpInputObject> _inputAllTypes = new();
  private readonly ForVU<IGqlpOutputObject> _outputAllTypes = new();
  private readonly ForVU<IGqlpDomain> _domainAllTypes = new();
  private readonly ForVU<IGqlpUnion> _unionAllTypes = new();
  private readonly VerifyAllTypes _verifier;

  public VerifyAllTypesTests()
    => _verifier = new(_dualAllTypes.Intf, _enumAllTypes.Intf, _inputAllTypes.Intf, _outputAllTypes.Intf, _domainAllTypes.Intf, _unionAllTypes.Intf);

  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    IGqlpType item1 = A.Error<IGqlpType>();
    IGqlpType item2 = A.Error<IGqlpType>();

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
    IGqlpType type = A.Enum("Enum", ["Alias"], "", "");

    _verifier.Verify([type], Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Schema_WithAliasDuplicates_ReturnsError()
  {
    IGqlpType type1 = A.Enum("Enum", ["Alias"], "", "");

    IGqlpType type2 = A.Union("Union", ["Alias"], "", "");

    _verifier.Verify([type1, type2], Errors);

    Errors.ShouldBeEmpty();
  }
}
