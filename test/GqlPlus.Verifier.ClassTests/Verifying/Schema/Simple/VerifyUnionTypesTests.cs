using GqlPlus.Abstractions.Schema;

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
    IGqlpUnionMember[] members = NForA<IGqlpUnionMember>("Member1", "Member2");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithDefinedMembers_ReturnsNoErrors()
  {
    Define<IGqlpEnum>("Member1", "Member2");

    IGqlpUnionMember[] members = NForA<IGqlpUnionMember>("Member1", "Member2");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithSelfMember_ReturnsError()
  {
    IGqlpUnionMember[] members = NForA<IGqlpUnionMember>("Union");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithSelfParent_ReturnsError()
  {
    _union.Parent.Returns("Union");

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithParentMembers_ReturnsNoErrors()
  {
    Define<IGqlpEnum>("Member1", "Member2", "Member3", "Member4");

    IGqlpUnion parent = NFor<IGqlpUnion>("Parent");
    IGqlpUnionMember[] parentMembers = NForA<IGqlpUnionMember>("Member3", "Member4");
    parent.Items.Returns(parentMembers);
    Definitions.Add(parent);

    IGqlpUnionMember[] members = [NFor<IGqlpUnionMember>("Member1"), NFor<IGqlpUnionMember>("Member2")];
    _union.Items.Returns(members);
    _union.Parent.Returns("Parent");

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _mergeMembers.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Union_WithUnionMember_ReturnsNoErrors()
  {
    Define<IGqlpEnum>("Member1", "Member2", "Member3", "Member4");

    IGqlpUnion member = NFor<IGqlpUnion>("Member");
    IGqlpUnionMember[] memberMembers = NForA<IGqlpUnionMember>("Member3", "Member4");
    member.Items.Returns(memberMembers);
    Definitions.Add(member);

    IGqlpUnionMember[] members = NForA<IGqlpUnionMember>("Member1", "Member2", "Member");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithUnionMemberWithSelfMember_ReturnsError()
  {
    Define<IGqlpEnum>("Member1", "Member2", "Member3", "Member4");

    IGqlpUnion member = NFor<IGqlpUnion>("Member");
    IGqlpUnionMember[] memberMembers = NForA<IGqlpUnionMember>("Member3", "Member4", "Union");
    member.Items.Returns(memberMembers);
    Definitions.Add(member);

    IGqlpUnionMember[] members = NForA<IGqlpUnionMember>("Member1", "Member2", "Member");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithUnionMemberWithSelfParent_ReturnsError()
  {
    Define<IGqlpEnum>("Member1", "Member2");

    IGqlpUnion parent = NFor<IGqlpUnion>("Parent");
    IGqlpUnionMember[] parentMembers = NForA<IGqlpUnionMember>("Member2", "Union");
    parent.Items.Returns(parentMembers);
    Definitions.Add(parent);

    IGqlpUnion member = NFor<IGqlpUnion>("Member");
    member.Parent.Returns("Parent");
    Definitions.Add(member);

    IGqlpUnionMember[] members = NForA<IGqlpUnionMember>("Member1", "Member");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
