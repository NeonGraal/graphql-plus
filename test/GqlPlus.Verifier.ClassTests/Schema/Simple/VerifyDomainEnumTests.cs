using GqlPlus.Abstractions.Schema;
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

    IGqlpEnumLabel item1 = NFor<IGqlpEnumLabel>("item1");
    IGqlpEnumLabel item2 = NFor<IGqlpEnumLabel>("item2");
    IGqlpEnum enumType = NFor<IGqlpEnum>("domain");
    enumType.HasValue("item1").Returns(true);
    enumType.HasValue("item2").Returns(true);
    enumType.Items.Returns([item1, item2]);
    Types["domain"] = enumType;

    EnumValues["item1"] = "domain";
    EnumValues["item2"] = "domain";

    IGqlpDomainLabel label1 = EFor<IGqlpDomainLabel>();
    label1.EnumItem.Returns("item1");
    label1.EnumType.Returns("", "domain");
    IGqlpDomainLabel label2 = EFor<IGqlpDomainLabel>();
    label2.EnumItem.Returns("item2");
    label2.EnumType.Returns("domain");
    label2.Excludes.Returns(true);
    IGqlpDomain<IGqlpDomainLabel> domain = NFor<IGqlpDomain<IGqlpDomainLabel>>("domain");
    domain.Items.Returns([label1, label2]);

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      Items.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  internal override AstDomainVerifier<IGqlpDomainLabel> NewDomainVerifier()
    => new VerifyDomainEnum(Items.Intf);
}
