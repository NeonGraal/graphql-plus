using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

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

  private static IGqlpEnumLabel CreateEnumLabel(string name)
  {
    IGqlpEnumLabel enumLabel = EFor<IGqlpEnumLabel>();
    enumLabel.Name.Returns(name);
    enumLabel.IsNameOrAlias(name).Returns(true);
    return enumLabel;
  }

  internal override AstDomainVerifier<IGqlpDomainLabel> NewDomainVerifier()
    => new VerifyDomainEnum(ItemsMerger.Intf);
}
