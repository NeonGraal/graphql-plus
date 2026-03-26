namespace GqlPlus.Generating.Simple;

public class DomainEnumGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainLabel>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IGqlpDomainLabel> Generator { get; }
    = new DomainEnumGenerator();

  [Theory, RepeatData]
  public void TypeMembers_WithNoEnumType_ReturnsNoPair(string domainName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpDomain<IGqlpDomainLabel> domainType = A.Named<IGqlpDomain<IGqlpDomainLabel>>(domainName);
    IGqlpDomainLabel item = A.Error<IGqlpDomainLabel>();
    domainType.Items.Returns([item]);

    // Act
    MapPair<string>[] result = [.. Generator.TypeMembers(domainType, context)];

    // Assert
    result.Length.ShouldBe(0);
  }

  [Theory, RepeatData]
  public void TypeMembers_WithSingleEnumType_ReturnsRealEnumType(string domainName, string enumTypeName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpDomain<IGqlpDomainLabel> domainType = A.Named<IGqlpDomain<IGqlpDomainLabel>>(domainName);
    IGqlpDomainLabel item = A.ItemLabel(enumTypeName, "item");
    domainType.Items.Returns([item]);

    // Act
    MapPair<string>[] result = [.. Generator.TypeMembers(domainType, context)];

    // Assert
    result.Length.ShouldBe(1);
    result[0].Key.ShouldBe("Value");
    result[0].Value.ShouldEndWith(enumTypeName + "?");
  }

  protected override IGqlpDomainLabel MakeDomainItem(string item)
    => A.ItemLabel("", item);
}
