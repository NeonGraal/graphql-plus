﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;
using NSubstitute;

namespace GqlPlus.Schema.Simple;

public class VerifyDomainEnumTests
  : AstDomainVerifierBase<IGqlpDomainLabel>
{

  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    AstDomainVerifier<IGqlpDomainLabel> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpEnum enumType = EFor<IGqlpEnum>();
    enumType.Name.Returns("domain");
    IGqlpEnumLabel item1 = EFor<IGqlpEnumLabel>();
    item1.Name.Returns("item1");
    IGqlpEnumLabel item2 = EFor<IGqlpEnumLabel>();
    item2.Name.Returns("item2");
    enumType.Items.Returns([item1, item2]);
    Types["domain"] = enumType;

    EnumValues["item1"] = "domain";
    EnumValues["item2"] = "domain";

    IGqlpDomain<IGqlpDomainLabel> domain = EFor<IGqlpDomain<IGqlpDomainLabel>>();
    domain.Name.Returns("domain");
    IGqlpDomainLabel label1 = EFor<IGqlpDomainLabel>();
    label1.EnumItem.Returns("item1");
    IGqlpDomainLabel label2 = EFor<IGqlpDomainLabel>();
    label2.EnumItem.Returns("item2");
    domain.Items.Returns([label1, label2]);

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      Items.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  internal override AstDomainVerifier<IGqlpDomainLabel> NewDomainVerifier()
    => new VerifyDomainEnum(Items.Intf);
}
