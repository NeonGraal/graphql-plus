using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyUnionTypesTests
  : UsageVerifierTestsBase<IAstUnion>
{
  private readonly ForM<IAstUnionMember> _mergeMembers = new();
  private readonly VerifyUnionTypes _verifier;

  private readonly UnionBuilder _union;
  private IAstUnion? _usage;

  protected override IAstUnion TheUsage => _usage ??= _union.AsUnion;
  protected override IVerifyUsage<IAstUnion> Verifier => _verifier;

  public VerifyUnionTypesTests()
  {
    MergerForReturns(_mergeMembers.Intf);
    _verifier = new(VerifierRepo);

    _union = new("Union");
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
    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithUndefinedMembers_ReturnsErrors()
  {
    _union.WithMembers(["Member1", "Member2"]);

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithDefinedMembers_ReturnsNoErrors()
  {
    Define<IAstEnum>("Member1", "Member2");

    _union.WithMembers(["Member1", "Member2"]);

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithSelfMember_ReturnsError()
  {
    _union.WithMembers(["Union"]);

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithSelfParent_ReturnsError()
  {
    _union.WithParent("Union");

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithParentMembers_ReturnsNoErrors()
  {
    Define<IAstEnum>("Member1", "Member2", "Member3", "Member4");

    IAstUnion parent = A.Union("Parent").WithMembers(["Member3", "Member4"]).AsUnion;
    Definitions.Add(parent);

    _union.WithMembers(["Member1", "Member2"]);
    _union.WithParent("Parent");

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _mergeMembers.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Union_WithUnionMember_ReturnsNoErrors()
  {
    Define<IAstEnum>("Member1", "Member2", "Member3", "Member4");

    IAstUnion member = A.Union("Member").WithMembers(["Member3", "Member4"]).AsUnion;
    Definitions.Add(member);

    _union.WithMembers(["Member1", "Member2", "Member"]);

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithUnionMemberWithSelfMember_ReturnsError()
  {
    Define<IAstEnum>("Member1", "Member2", "Member3", "Member4");

    IAstUnion member = A.Union("Member").WithMembers(["Member3", "Member4", "Union"]).AsUnion;
    Definitions.Add(member);

    _union.WithMembers(["Member1", "Member2", "Member"]);

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Union_WithUnionMemberWithSelfParent_ReturnsError()
  {
    Define<IAstEnum>("Member1", "Member2");

    IAstUnion parent = A.Union("Parent").WithMembers(["Member2", "Union"]).AsUnion;
    Definitions.Add(parent);

    IAstUnion member = A.Union("Member").WithParent("Parent").AsUnion;
    Definitions.Add(member);

    _union.WithMembers(["Member1", "Member"]);

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
