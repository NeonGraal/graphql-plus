using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Schema;

[TracePerTest]
public class VerifyAllTypesTests
  : VerifierBase
{
  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    ForVU<IGqlpDualObject> dualAllTypes = new();
    ForVU<IGqlpEnum> enumAllTypes = new();
    ForVU<IGqlpInputObject> inputAllTypes = new();
    ForVU<IGqlpOutputObject> outputAllTypes = new();
    ForVU<IGqlpDomain> domainAllTypes = new();
    ForVU<IGqlpUnion> unionAllTypes = new();

    VerifyAllTypes verifier = new(dualAllTypes.Intf, enumAllTypes.Intf, inputAllTypes.Intf, outputAllTypes.Intf, domainAllTypes.Intf, unionAllTypes.Intf);

    IGqlpType item1 = EFor<IGqlpType>();
    IGqlpType item2 = EFor<IGqlpType>();

    verifier.Verify([item1, item2], Errors);

    using AssertionScope scope = new();

    dualAllTypes.Called();
    enumAllTypes.Called();
    inputAllTypes.Called();
    outputAllTypes.Called();
    domainAllTypes.Called();
    unionAllTypes.Called();

    Errors.Should().BeNullOrEmpty();
  }
}
