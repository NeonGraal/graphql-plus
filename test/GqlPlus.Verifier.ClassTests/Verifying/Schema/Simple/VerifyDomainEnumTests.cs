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

  [Theory, RepeatData]
  public void Verify_Enum_WithDefinedLabels_ReturnsNoErrrors(string enumName, string enumLabel1, string enumLabel2)
  {
    this.SkipEqual(enumLabel1, enumLabel2);

    IGqlpEnum enumType = A.Enum(enumName)
      .WithLabels(A.Aliased<IGqlpEnumLabel>(enumLabel1, ["i1"]), A.Aliased<IGqlpEnumLabel>(enumLabel2, ["i2"]))
      .AsEnum;
    AddTypes(enumType);
    EnumValues[enumLabel1] = enumName;

    _context = new(Types, Errors, Types.Values.ArrayOf<IGqlpType>().MakeEnumValues());

    IGqlpDomainLabel label1 = A.DomainLabel("", enumLabel1);
    IGqlpDomainLabel label2 = A.DomainLabel(enumName, enumLabel2);
    label2.Excludes.Returns(true);

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_CallsVerifierAndMergerWithoutErrors(string domainName, string enumName, string enumLabel1, string enumLabel2)
  {
    this.SkipEqual(enumLabel1, enumLabel2);

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpEnum enumType = A.Enum(enumName, [enumLabel1, enumLabel2]);
    AddTypes(enumType);

    EnumValues[enumLabel1] = enumName;
    EnumValues[enumLabel2] = enumName;

    IGqlpDomainLabel label1 = A.DomainLabel("", enumLabel1);
    IGqlpDomainLabel label2 = A.DomainLabel(enumName, enumLabel2);
    label2.Excludes.Returns(true);
    IGqlpDomain<IGqlpDomainLabel> domain = A.Domain(domainName, DomainKind.Enum, label1, label2);

    _verifier.Verify(domain, context);

    _verifier.ShouldSatisfyAllConditions(
      ItemsMerger.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithUndefinedEnum_ReturnsError(string enumName, string enumLabel)
  {
    IGqlpDomainLabel label1 = A.DomainLabel(enumName, " * ");
    IGqlpDomainLabel label2 = A.DomainLabel(enumName, enumLabel);
    label2.Excludes.Returns(true);

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithUndefinedLabel_ReturnsError(string enumName, string enumLabel)
  {
    IGqlpEnum enumType = A.Enum(enumName, [enumLabel]);
    AddTypes(enumType);

    IGqlpDomainLabel label1 = A.DomainLabel(enumName, enumLabel + "z");
    IGqlpDomainLabel label2 = A.DomainLabel("", enumLabel + "z");
    label2.Excludes.Returns(true);

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithDuplicateLabel_ReturnsError(string enumName1, string enumName2, string enumLabel)
  {
    this.SkipEqual(enumName1, enumName2);

    IGqlpEnum enum1 = A.Enum(enumName1, [enumLabel]);
    IGqlpEnum enum2 = A.Enum(enumName2, [enumLabel]);
    AddTypes(enum1, enum2);

    IGqlpDomainLabel label1 = A.DomainLabel(enumName1, "*");
    IGqlpDomainLabel label2 = A.DomainLabel(enumName2, "*");

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithDuplicateParentLabel_ReturnsError(string enumName1, string enumLabel1, string enumLabel2, string parentName, string parentLabel1, string parentLabel2, string enumName2)
  {
    this.SkipEqual3(enumName1, enumName2, parentName);
    this.SkipEqual4(enumLabel1, enumLabel2, parentLabel1, parentLabel2);

    IGqlpEnum enum1 = A.Enum(enumName1).WithLabels([enumLabel1, enumLabel2]).WithParent(parentName).AsEnum;
    IGqlpEnum parent = A.Enum(parentName).WithLabels([parentLabel1, parentLabel2]).AsEnum;
    IGqlpEnum enum2 = A.Enum(enumName2).WithLabels([parentLabel1]).AsEnum;
    AddTypes(enum1, parent, enum2);

    IGqlpDomainLabel label1 = A.DomainLabel(enumName1, "*");
    IGqlpDomainLabel label2 = A.DomainLabel(enumName2, "*");

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithParentDuplicateLabel_ReturnsError(string enumName1, string enumName2, string labelName, string parentName)
  {
    this.SkipEqual3(enumName1, enumName2, parentName);

    IGqlpDomainLabel parentLabel = A.DomainLabel(enumName2, labelName);
    IGqlpDomain<IGqlpDomainLabel> parent = A.Domain(parentName, DomainKind.Enum, parentLabel);

    IGqlpEnum enum1 = A.Enum(enumName1).WithLabels([labelName]).AsEnum;
    IGqlpEnum enum2 = A.Enum(enumName2).WithLabels([labelName]).AsEnum;
    AddTypes(parent, enum1, enum2);

    IGqlpDomainLabel enumLabel = A.DomainLabel(enumName1, labelName);

    _domain.WithParent(parentName).WithItems(enumLabel);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  internal override AstDomainVerifier<IGqlpDomainLabel> NewDomainVerifier()
    => _verifier;
}
