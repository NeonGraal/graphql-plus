using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;
using NSubstitute;

namespace GqlPlus.Schema.Simple;

public class VerifyDomainEnumTests
  : AstDomainVerifierBase<IGqlpDomainMember>
{

  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    AstDomainVerifier<IGqlpDomainMember> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpEnum enumType = EFor<IGqlpEnum>();
    enumType.Name.Returns("domain");
    IGqlpEnumItem item1 = EFor<IGqlpEnumItem>();
    item1.Name.Returns("item1");
    IGqlpEnumItem item2 = EFor<IGqlpEnumItem>();
    item2.Name.Returns("item2");
    enumType.Items.Returns([item1, item2]);
    Types["domain"] = enumType;

    EnumValues["item1"] = "domain";
    EnumValues["item2"] = "domain";

    IGqlpDomain<IGqlpDomainMember> domain = EFor<IGqlpDomain<IGqlpDomainMember>>();
    domain.Name.Returns("domain");
    IGqlpDomainMember member1 = EFor<IGqlpDomainMember>();
    member1.EnumItem.Returns("item1");
    IGqlpDomainMember member2 = EFor<IGqlpDomainMember>();
    member2.EnumItem.Returns("item2");
    domain.Items.Returns([member1, member2]);

    verifier.Verify(domain, context);

    using AssertionScope scope = new();

    Members.NotCalled();
    Errors.Should().BeNullOrEmpty();
  }

  internal override AstDomainVerifier<IGqlpDomainMember> NewDomainVerifier()
    => new VerifyDomainEnum(Members.Intf);
}
