namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyDomainTypesTests
  : UsageVerifierTestsBase<IGqlpDomain>
{
  private readonly IVerifyDomain _domainVerify = A.Of<IVerifyDomain>();
  private readonly VerifyDomainTypes _verifier;

  private readonly IGqlpDomain _domain;
  private readonly IGqlpDomainRegex _domainRegex = A.Error<IGqlpDomainRegex>();

  protected override IGqlpDomain TheUsage => _domain;
  protected override IVerifyUsage<IGqlpDomain> Verifier => _verifier;

  public VerifyDomainTypesTests()
  {
    _verifier = new(Aliased.Intf, [_domainVerify]);

    _domain = A.Domain("Domain", DomainKind.String, _domainRegex);
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
    IGqlpDomain parent = A.Domain("Parent", DomainKind.String, _domainRegex);
    Definitions.Add(parent);

    IGqlpTypeRef parentRef = A.Named<IGqlpTypeRef>("Parent");
    _domain.Parent.Returns(parentRef);

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Domain_WithSameParentMergeErrors_ReturnsMoreErrors()
  {
    IGqlpDomain parent = A.Domain("Parent", DomainKind.String, _domainRegex);
    Definitions.Add(parent);

    IGqlpTypeRef parentRef = A.Named<IGqlpTypeRef>("Parent");
    _domain.Parent.Returns(parentRef);

    _domainVerify.CanMergeItems(_domain, Arg.Any<EnumContext>()).Returns("merge error".MakeMessages());

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.Count.ShouldBeGreaterThan(1);
  }

  [Fact]
  public void Verify_Domain_WithDiffKindParent_ReturnsError()
  {
    IGqlpDomain parent = A.Domain<IGqlpDomainRange>("Parent", DomainKind.Number);
    Definitions.Add(parent);

    _domain.DomainKind.Returns(DomainKind.String);
    IGqlpTypeRef parentRef = A.Named<IGqlpTypeRef>("Parent");
    _domain.Parent.Returns(parentRef);

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
