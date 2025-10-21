using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Verifying.Schema.Simple;

public class VerifyDomainEnumTests
  : AstDomainVerifierTestsBase<IGqlpDomainLabel>
{
  private readonly VerifyDomainEnum _verifier;
  private EnumContext _context;

  private readonly DomainBuilder<IGqlpDomainLabel> _domain;

  public VerifyDomainEnumTests()
  {
    _verifier = new VerifyDomainEnum(ItemsMerger.Intf);

    _context = new(Types, Errors, EnumValues);

    _domain = A.Domain<IGqlpDomainLabel>("domain", DomainKind.Enum);
  }

  [Fact]
  public void Verify_Enum_WithDefinedLabels_ReturnsNoErrrors()
  {
    IGqlpEnum enumType = A.Enum("domain")
      .WithLabels([A.Aliased<IGqlpEnumLabel>("item1", ["i1"]), A.Aliased<IGqlpEnumLabel>("item2", ["i2"])])
      .AsEnum;
    AddTypes(enumType);
    EnumValues["item1"] = "domain";

    _context = new(Types, Errors, Types.Values.ArrayOf<IGqlpType>().MakeEnumValues());

    IGqlpDomainLabel label1 = A.DomainLabel("domain", "item1");
    label1.EnumType.Returns("", "domain");
    IGqlpDomainLabel label2 = A.DomainLabel("domain", "item2");
    label2.Excludes.Returns(true);

    _domain.WithItems([label1, label2]);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    AstDomainVerifier<IGqlpDomainLabel> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpEnum enumType = A.Enum("domain", ["item1", "item2"]);
    AddTypes(enumType);

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

    _domain.WithItems([label1, label2]);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Enum_WithUndefinedLabel_ReturnsError()
  {
    IGqlpEnum enumType = A.Enum("domain", ["item1"]);
    AddTypes(enumType);

    IGqlpDomainLabel label1 = A.DomainLabel("domain", "item2");
    IGqlpDomainLabel label2 = A.DomainLabel("", "item2");
    label2.Excludes.Returns(true);

    _domain.WithItems([label1, label2]);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Enum_WithDuplicateLabel_ReturnsError()
  {
    IGqlpEnum enum1 = A.Enum("domain1", ["item1"]);
    IGqlpEnum enum2 = A.Enum("domain2", ["item1"]);
    AddTypes(enum1, enum2);

    IGqlpDomainLabel label1 = A.DomainLabel("domain1", "*");
    IGqlpDomainLabel label2 = A.DomainLabel("domain2", "*");

    _domain.WithItems([label1, label2]);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Fact(Skip = "WIP")]
  public void Verify_Enum_WithDuplicateParentLabel_ReturnsError()
  {
    IGqlpEnum enumType = A.Enum("domain1").WithLabels(["item1", "item2"]).WithParent("parent").AsEnum;
    IGqlpEnum parent = A.Enum("parent").WithLabels(["item3", "item4"]).AsEnum;
    IGqlpEnum enum2 = A.Enum("domain2").WithLabels(["item3"]).AsEnum;
    AddTypes(enumType, parent, enum2);

    IGqlpDomainLabel label1 = A.DomainLabel("domain1", "*");
    IGqlpDomainLabel label2 = A.DomainLabel("domain2", "*");

    _domain.WithItems([label1, label2]);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  internal override AstDomainVerifier<IGqlpDomainLabel> NewDomainVerifier()
    => _verifier;
}
