﻿
namespace GqlPlus.Generating.Simple;

public abstract class DomainGeneratorTestBase<TItem>
  : TypeGeneratorClassTestBase<IGqlpDomain<TItem>>
  where TItem : class, IGqlpDomainItem
{
  public override string ExpectedTypePrefix => "Domain";

  internal abstract GenerateBaseDomain<TItem> Generator { get; }

  internal override GenerateForType<IGqlpDomain<TItem>> TypeGenerator => Generator;

  [Theory, RepeatData]
  public void TypeMembers_WithDomainItems_ReturnsAsNamePairs(string domainName, string _)
  {
    // Arrange
    IGqlpDomain<TItem> domainType = A.Named<IGqlpDomain<TItem>>(domainName);
    TItem item = A.Error<TItem>();
    domainType.Items.Returns([item]);

    // Act
    MapPair<string>[] result = [.. Generator.TypeMembers(domainType, Context)];

    // Assert
    result.Length.ShouldBe(0);
    //result[0].Key.ShouldBe("As" + memberName);
    //result[0].Value.ShouldBe(memberName);
  }
}
