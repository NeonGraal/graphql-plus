using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyUnionTypesTests
  : UsageVerifierBase<IGqlpUnion>
{
  private readonly ForM<IGqlpUnionMember> _mergeMembers = new();
  private readonly VerifyUnionTypes _verifier;
  private readonly IGqlpUnion _union;

  public VerifyUnionTypesTests()
  {
    _verifier = new(Aliased.Intf, _mergeMembers.Intf);

    _union = NFor<IGqlpUnion>("Union");
  }

  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      _mergeMembers.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Union_ReturnsNoErrors()
  {
    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithUndefinedMembers_ReturnsErrors()
  {
    IGqlpUnionMember[] members = [NFor<IGqlpUnionMember>("Member1"), NFor<IGqlpUnionMember>("Member2")];
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithDefinedMembers_ReturnsNoErrors()
  {
    Definitions.Add(NFor<IGqlpEnum>("Member1"));
    Definitions.Add(NFor<IGqlpEnum>("Member2"));

    IGqlpUnionMember[] members = [NFor<IGqlpUnionMember>("Member1"), NFor<IGqlpUnionMember>("Member2")];
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
