using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Verifying.Schema.Simple;

public class VerifyDomainEnumTests
  : AstDomainVerifierTestsBase<IAstDomainLabel>
{
  private readonly VerifyDomainEnum _verifier;
  private EnumContext _context;

  private readonly DomainBuilder<IAstDomainLabel> _domain;

  public VerifyDomainEnumTests()
    : base(DomainKind.Enum)
  {
    _verifier = new VerifyDomainEnum(VerifierRepo);

    _context = new(Types, Errors, EnumValues);

    _domain = A.Domain<IAstDomainLabel>("domain", DomainKind.Enum);
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithDefinedLabels_ReturnsNoErrrors(string enumName, string enumLabel1, string enumLabel2, string alias1, string alias2)
  {
    this.SkipEqualAny([enumLabel1, enumLabel2, alias1, alias2]);

    IAstEnum enumType = A.Enum(enumName)
      .WithLabels(A.Aliased<IAstEnumLabel>(enumLabel1, [alias1]), A.Aliased<IAstEnumLabel>(enumLabel2, [alias2]))
      .AsEnum;
    AddTypes(enumType);
    EnumValues[enumLabel1] = enumName;

    _context = new(Types, Errors, Types.Values.ArrayOf<IAstType>().MakeEnumValues());

    IAstDomainLabel label1 = A.ItemLabel("", enumLabel1);
    IAstDomainLabel label2 = A.ItemLabel(enumName, enumLabel2);
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

    IAstEnum enumType = A.Enum(enumName, [enumLabel1, enumLabel2]);
    AddTypes(enumType);

    EnumValues[enumLabel1] = enumName;
    EnumValues[enumLabel2] = enumName;

    IAstDomainLabel label1 = A.ItemLabel("", enumLabel1);
    IAstDomainLabel label2 = A.ItemLabel(enumName, enumLabel2);
    label2.Excludes.Returns(true);
    IAstDomain<IAstDomainLabel> domain = A.Domain(domainName, DomainKind.Enum, label1, label2);

    _verifier.Verify(domain, context);

    _verifier.ShouldSatisfyAllConditions(
      ItemsMerger.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithUndefinedEnum_ReturnsError(string enumName, string enumLabel)
  {
    IAstDomainLabel label1 = A.ItemLabel(enumName, GqlpDomainLabelConstants.All);
    IAstDomainLabel label2 = A.ItemLabel(enumName, enumLabel);
    label2.Excludes.Returns(true);

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithUndefinedLabel_ReturnsError(string enumName, string enumLabel)
  {
    IAstEnum enumType = A.Enum(enumName, [enumLabel]);
    AddTypes(enumType);

    IAstDomainLabel label1 = A.ItemLabel(enumName, enumLabel + "z");
    IAstDomainLabel label2 = A.ItemLabel("", enumLabel + "z");
    label2.Excludes.Returns(true);

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithDuplicateLabel_ReturnsError(string enumName1, string enumName2, string enumLabel)
  {
    this.SkipEqual(enumName1, enumName2);

    IAstEnum enum1 = A.Enum(enumName1, [enumLabel]);
    IAstEnum enum2 = A.Enum(enumName2, [enumLabel]);
    AddTypes(enum1, enum2);

    IAstDomainLabel label1 = A.ItemLabel(enumName1, GqlpDomainLabelConstants.All);
    IAstDomainLabel label2 = A.ItemLabel(enumName2, GqlpDomainLabelConstants.All);

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithDuplicateParentLabel_ReturnsError(
    string enumName1,
    string enumLabel1,
    string enumLabel2,
    string parentName,
    string parentLabel1,
    string parentLabel2,
    string enumName2)
  {
    this.SkipEqualAny([enumName1, enumName2, parentName]);
    this.SkipEqualAny([enumLabel1, enumLabel2, parentLabel1, parentLabel2]);

    IAstEnum enum1 = A.Enum(enumName1).WithLabels([enumLabel1, enumLabel2]).WithParent(parentName).AsEnum;
    IAstEnum parent = A.Enum(parentName).WithLabels([parentLabel1, parentLabel2]).AsEnum;
    IAstEnum enum2 = A.Enum(enumName2).WithLabels([parentLabel1]).AsEnum;
    AddTypes(enum1, parent, enum2);

    IAstDomainLabel label1 = A.ItemLabel(enumName1, GqlpDomainLabelConstants.All);
    IAstDomainLabel label2 = A.ItemLabel(enumName2, GqlpDomainLabelConstants.All);

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithParentDuplicateLabel_ReturnsError(string enumName1, string enumName2, string labelName, string parentName)
  {
    this.SkipEqualAny([enumName1, enumName2, parentName]);

    IAstDomainLabel parentLabel = A.ItemLabel(enumName2, labelName);
    IAstDomain<IAstDomainLabel> parent = A.Domain(parentName, DomainKind.Enum, parentLabel);

    IAstEnum enum1 = A.Enum(enumName1).WithLabels([labelName]).AsEnum;
    IAstEnum enum2 = A.Enum(enumName2).WithLabels([labelName]).AsEnum;
    AddTypes(parent, enum1, enum2);

    IAstDomainLabel enumLabel = A.ItemLabel(enumName1, labelName);

    _domain.WithParent(parentName).WithItems(enumLabel);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithExcludedAll_ReturnsError(string enumName, string enumLabel)
  {
    IAstEnum enumType = A.Enum(enumName, [enumLabel]);
    AddTypes(enumType);

    IAstDomainLabel label1 = A.ItemLabel(enumName, GqlpDomainLabelConstants.All);
    label1.Excludes.Returns(true);

    _domain.WithItems(label1);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_Enum_WithExcludedLabel_ReturnsError(string enumName, string enumLabel, string otherLabel)
  {
    IAstEnum enumType = A.Enum(enumName, [enumLabel, otherLabel]);
    AddTypes(enumType);

    IAstDomainLabel label1 = A.ItemLabel(enumName, GqlpDomainLabelConstants.All);
    label1.Excludes.Returns(true);
    IAstDomainLabel label2 = A.ItemLabel(enumName, enumLabel);

    _domain.WithItems(label1, label2);

    _verifier.Verify(_domain.AsDomain, _context);

    Errors.ShouldNotBeEmpty();
  }

  internal override AstDomainVerifier<IAstDomainLabel> NewDomainVerifier()
    => _verifier;
  internal override IAstDomainLabel NewItem()
  {
    IAstEnum enumType = A.Enum("enum", ["label"]);
    AddTypes(enumType);

    return A.ItemLabel("enum", "label");
  }
}
