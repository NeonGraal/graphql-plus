using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyDomainTypesTests
  : UsageVerifierTestsBase<IGqlpDomain>
{
  private readonly IVerifyDomain _domainVerify = For<IVerifyDomain>();
  private readonly VerifyDomainTypes _verifier;

  private readonly IGqlpDomain _domain;

  protected override IGqlpDomain TheUsage => _domain;
  protected override IVerifyUsage<IGqlpDomain> Verifier => _verifier;

  public VerifyDomainTypesTests()
  {
    _verifier = new(Aliased.Intf, [_domainVerify]);

    _domain = NFor<IGqlpDomain>("Domain");
  }

  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Domain_ReturnsNoErrors()
  {
    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Domain_WithSameParent_ReturnsNoErrors()
  {
    IGqlpDomain parent = NFor<IGqlpDomain>("Parent");
    parent.DomainKind.Returns(DomainKind.String);
    Definitions.Add(parent);

    _domain.DomainKind.Returns(DomainKind.String);
    _domain.Parent.Returns("Parent");

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Domain_WithSameParentMergeErrors_ReturnsMoreErrors()
  {
    IGqlpDomain parent = NFor<IGqlpDomain>("Parent");
    parent.DomainKind.Returns(DomainKind.String);
    Definitions.Add(parent);

    _domain.DomainKind.Returns(DomainKind.String);
    _domain.Parent.Returns("Parent");

    _domainVerify.CanMergeItems(_domain, Arg.Any<EnumContext>()).Returns(MakeMessages("merge error"));

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.Count.ShouldBeGreaterThan(1);
  }

  [Fact]
  public void Verify_Domain_WithDiffKindParent_ReturnsError()
  {
    IGqlpDomain parent = NFor<IGqlpDomain>("Parent");
    parent.DomainKind.Returns(DomainKind.Number);
    Definitions.Add(parent);

    _domain.DomainKind.Returns(DomainKind.String);
    _domain.Parent.Returns("Parent");

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
