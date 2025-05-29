﻿using GqlPlus.Abstractions.Schema;

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

    _domain = NFor<IGqlpDomain<IGqlpDomainLabel>>("domain");
  }

  [Fact(Skip = "WIP")]
  public void Verify_Enum_WithDefinedLabels_ReturnsNoErrrors()
  {
    IGqlpEnum enumType = Enum("domain", "item1", "item2");

    IGqlpDomainLabel label1 = EnumLabel("item1", "domain");
    label1.EnumType.Returns("", "domain");
    IGqlpDomainLabel label2 = EnumLabel("item2", "domain");
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

    IGqlpEnum enumType = EFor<IGqlpEnum>();
    enumType.Name.Returns("domain");
    enumType.HasValue("item1").Returns(true);
    enumType.HasValue("item2").Returns(true);
    IGqlpEnumLabel item1 = CreateEnumLabel("item1");
    IGqlpEnumLabel item2 = CreateEnumLabel("item2");
    enumType.Items.Returns([item1, item2]);
    Types["domain"] = enumType;

    EnumValues["item1"] = "domain";
    EnumValues["item2"] = "domain";

    IGqlpDomain<IGqlpDomainLabel> domain = EFor<IGqlpDomain<IGqlpDomainLabel>>();
    domain.Name.Returns("domain");
    IGqlpDomainLabel label1 = EFor<IGqlpDomainLabel>();
    label1.EnumItem.Returns("item1");
    label1.EnumType.Returns("", "domain");
    IGqlpDomainLabel label2 = EFor<IGqlpDomainLabel>();
    label2.EnumItem.Returns("item2");
    label2.EnumType.Returns("domain");
    label2.Excludes.Returns(true);
    domain.Items.Returns([label1, label2]);

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      ItemsMerger.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Enum_WithUndefinedEnum_ReturnsError()
  {
    IGqlpDomainLabel label1 = EnumLabel("*", "domain");
    IGqlpDomainLabel label2 = EnumLabel("item2", "domain");
    label2.Excludes.Returns(true);

    _domain.Items.Returns([label1, label2]);

    _verifier.Verify(_domain, _context);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Enum_WithUndefinedLabel_ReturnsError()
  {
    IGqlpEnum enumType = Enum("domain", "item1");

    IGqlpDomainLabel label1 = EnumLabel("item2", "domain");
    IGqlpDomainLabel label2 = EnumLabel("item2", "");
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

    IGqlpDomainLabel label1 = EnumLabel("*", "domain1");
    IGqlpDomainLabel label2 = EnumLabel("*", "domain2");

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

    IGqlpDomainLabel label1 = EnumLabel("*", "domain1");
    IGqlpDomainLabel label2 = EnumLabel("*", "domain2");

    _domain.Items.Returns([label1, label2]);

    _verifier.Verify(_domain, _context);

    Errors.ShouldNotBeEmpty();
  }

  internal override AstDomainVerifier<IGqlpDomainLabel> NewDomainVerifier()
    => _verifier;

  private static IGqlpDomainLabel EnumLabel(string label, string type)
  {
    IGqlpDomainLabel result = EFor<IGqlpDomainLabel>();
    result.EnumItem.Returns(label);
    result.EnumType.Returns(type);
    return result;
  }

  private static IGqlpEnumLabel CreateEnumLabel(string name)
  {
    IGqlpEnumLabel enumLabel = EFor<IGqlpEnumLabel>();
    enumLabel.Name.Returns(name);
    enumLabel.IsNameOrAlias(name).Returns(true);
    return enumLabel;
  }
}
