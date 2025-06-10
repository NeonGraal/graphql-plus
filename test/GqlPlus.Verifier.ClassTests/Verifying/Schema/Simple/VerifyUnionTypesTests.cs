namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyUnionTypesTests
  : UsageVerifierTestsBase<IGqlpUnion>
{
  private readonly ForM<IGqlpUnionMember> _mergeMembers = new();
  private readonly VerifyUnionTypes _verifier;
  private readonly IGqlpUnion _union;

  protected override IGqlpUnion TheUsage => _union;
  protected override IVerifyUsage<IGqlpUnion> Verifier => _verifier;

  public VerifyUnionTypesTests()
  {
    _verifier = new(Aliased.Intf, _mergeMembers.Intf);

    _union = A.Union("Union");
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
    IGqlpUnionMember[] members = A.NamedArray<IGqlpUnionMember>("Member1", "Member2");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithDefinedMembers_ReturnsNoErrors()
  {
    Define<IGqlpEnum>("Member1", "Member2");

    IGqlpUnionMember[] members = A.NamedArray<IGqlpUnionMember>("Member1", "Member2");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithSelfMember_ReturnsError()
  {
    IGqlpUnionMember[] members = A.NamedArray<IGqlpUnionMember>("Union");
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

    IGqlpUnion parent = A.Union("Parent", "Member3", "Member4");
    Definitions.Add(parent);

    IGqlpUnionMember[] members = A.NamedArray<IGqlpUnionMember>("Member1", "Member2");
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

    IGqlpUnion member = A.Union("Member", "Member3", "Member4");
    Definitions.Add(member);

    IGqlpUnionMember[] members = A.NamedArray<IGqlpUnionMember>("Member1", "Member2", "Member");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithUnionMemberWithSelfMember_ReturnsError()
  {
    Define<IGqlpEnum>("Member1", "Member2", "Member3", "Member4");

    IGqlpUnion member = A.Union("Member", "Member3", "Member4", "Union");
    Definitions.Add(member);

    IGqlpUnionMember[] members = A.NamedArray<IGqlpUnionMember>("Member1", "Member2", "Member");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithUnionMemberWithSelfParent_ReturnsError()
  {
    Define<IGqlpEnum>("Member1", "Member2");

    IGqlpUnion parent = A.Union("Parent", "Member2", "Union");
    Definitions.Add(parent);

    IGqlpUnion member = A.Union("Member");
    member.Parent.Returns("Parent");
    Definitions.Add(member);

    IGqlpUnionMember[] members = A.NamedArray<IGqlpUnionMember>("Member1", "Member");
    _union.Items.Returns(members);

    Usages.Add(_union);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
