namespace GqlPlus.Verifying.Schema.Simple;

public class VerifyDomainEnumTests
  : AstDomainVerifierTestsBase<IGqlpDomainLabel>
{
  private readonly VerifyDomainEnum _verifier;
  private readonly EnumContext _context;

  private readonly IGqlpDomain<IGqlpDomainLabel> _domain;

  public VerifyDomainEnumTests()
  {
    _verifier = new VerifyDomainEnum(ItemsMerger.Intf);

    _context = new(Types, Errors, EnumValues);

    _domain = A.Domain<IGqlpDomainLabel>("domain", DomainKind.Enum);
  }

  [Fact(Skip = "WIP")]
  public void Verify_Enum_WithDefinedLabels_ReturnsNoErrrors()
  {
    IGqlpEnum enumType = Enum("domain", "item1", "item2");

    IGqlpDomainLabel label1 = A.DomainLabel("domain", "item1");
    label1.EnumType.Returns("", "domain");
    IGqlpDomainLabel label2 = A.DomainLabel("domain", "item2");
    label2.Excludes.Returns(true);

    _domain.Items.Returns([label1, label2]);

    _verifier.Verify(_domain, _context);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    AstDomainVerifier<IGqlpDomainLabel> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpEnum enumType = A.Enum("domain", ["item1", "item2"]);
    Types["domain"] = enumType;

    EnumValues["item1"] = "domain";
    EnumValues["item2"] = "domain";

    IGqlpDomainLabel label1 = A.DomainLabel("", "item1");
    label1.EnumType.Returns("", "domain");
    IGqlpDomainLabel label2 = A.DomainLabel("domain", "item2");
    label2.Excludes.Returns(true);
    IGqlpDomain<IGqlpDomainLabel> domain = A.Domain("domain", DomainKind.Enum, label1, label2);

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      ItemsMerger.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Enum_WithUndefinedEnum_ReturnsError()
  {
    IGqlpDomainLabel label1 = A.DomainLabel("domain", "*");
    IGqlpDomainLabel label2 = A.DomainLabel("domain", "item2");
    label2.Excludes.Returns(true);

    _domain.Items.Returns([label1, label2]);

    _verifier.Verify(_domain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Enum_WithUndefinedLabel_ReturnsError()
  {
    IGqlpEnum enumType = Enum("domain", "item1");

    IGqlpDomainLabel label1 = A.DomainLabel("domain", "item2");
    IGqlpDomainLabel label2 = A.DomainLabel("", "item2");
    label2.Excludes.Returns(true);

    _domain.Items.Returns([label1, label2]);

    _verifier.Verify(_domain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Fact(Skip = "WIP")]
  public void Verify_Enum_WithDuplicateLabel_ReturnsError()
  {
    IGqlpEnum enum1 = Enum("domain1", "item1");
    IGqlpEnum enum2 = Enum("domain2", "item1");

    IGqlpDomainLabel label1 = A.DomainLabel("domain1", "*");
    IGqlpDomainLabel label2 = A.DomainLabel("domain2", "*");

    _domain.Items.Returns([label1, label2]);

    _verifier.Verify(_domain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Fact(Skip = "WIP")]
  public void Verify_Enum_WithDuplicateParentLabel_ReturnsError()
  {
    IGqlpEnum enumType = Enum("domain1", "item1", "item2");
    IGqlpEnum parent = Enum("parent", "item3", "item4");
    enumType.Parent.Returns("parent");
    IGqlpEnum enum2 = Enum("domain2", "item3");

    IGqlpDomainLabel label1 = A.DomainLabel("domain1", "*");
    IGqlpDomainLabel label2 = A.DomainLabel("domain2", "*");

    _domain.Items.Returns([label1, label2]);

    _verifier.Verify(_domain, _context);

    Errors.ShouldNotBeEmpty();
  }

  internal override AstDomainVerifier<IGqlpDomainLabel> NewDomainVerifier()
    => _verifier;
}
