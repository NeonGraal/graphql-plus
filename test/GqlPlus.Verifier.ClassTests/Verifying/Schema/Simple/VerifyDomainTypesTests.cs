namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyDomainTypesTests
  : UsageVerifierTestsBase<IAstDomain>
{
  private readonly IVerifyDomain _domainVerify = A.Of<IVerifyDomain>();
  private readonly VerifyDomainTypes _verifier;

  private readonly IAstDomain _domain;
  private readonly IAstDomainRegex _domainRegex = A.Error<IAstDomainRegex>();

  protected override IAstDomain TheUsage => _domain;
  protected override IVerifyUsage<IAstDomain> Verifier => _verifier;

  public VerifyDomainTypesTests()
  {
    GetDomainsReturns(_domainVerify);
    _verifier = new(VerifierRepo);

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
    IAstDomain parent = A.Domain("Parent", DomainKind.String, _domainRegex);
    Definitions.Add(parent);

    IAstTypeRef parentRef = A.Named<IAstTypeRef>("Parent");
    _domain.Parent.Returns(parentRef);

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Domain_WithSameParentMergeErrors_ReturnsMoreErrors()
  {
    IAstDomain parent = A.Domain("Parent", DomainKind.String, _domainRegex);
    Definitions.Add(parent);

    IAstTypeRef parentRef = A.Named<IAstTypeRef>("Parent");
    _domain.Parent.Returns(parentRef);

    _domainVerify.CanMergeItems(_domain, Arg.Any<EnumContext>()).Returns("merge error".MakeMessages());

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.Count.ShouldBeGreaterThan(1);
  }

  [Fact]
  public void Verify_Domain_WithDiffKindParent_ReturnsError()
  {
    IAstDomain parent = A.Domain<IAstDomainRange>("Parent", DomainKind.Number).AsDomain;
    Definitions.Add(parent);

    _domain.DomainKind.Returns(DomainKind.String);
    IAstTypeRef parentRef = A.Named<IAstTypeRef>("Parent");
    _domain.Parent.Returns(parentRef);

    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
