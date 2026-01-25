namespace GqlPlus.Generating.Simple;

public abstract class GenerateDomainTestsBase<TItem>
  : GenerateSimpleTestsBase<IGqlpDomain<TItem>>
  where TItem : class, IGqlpDomainItem
{
  internal abstract GenerateBaseDomain<TItem> Generator { get; }
  protected abstract DomainKind Kind { get; }

  internal override GenerateForType<IGqlpDomain<TItem>> TypeGenerator => Generator;

  [Theory, RepeatData]
  public void TypeMembers_WithDomainItems_ReturnsAsNamePairs(string domainName, string _)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpDomain<TItem> domainType = A.Named<IGqlpDomain<TItem>>(domainName);
    TItem item = A.Error<TItem>();
    domainType.Items.Returns([item]);

    // Act
    MapPair<string>[] result = [.. Generator.TypeMembers(domainType, context)];

    // Assert
    result.Length.ShouldBe(0);
    //result[0].Key.ShouldBe("As" + memberName);
    //result[0].Value.ShouldBe(memberName);
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithoutParent_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpDomain<TItem> type = A.Domain<TItem>(name, Kind).AsDomain;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckForRequired(
      GeneratedCodeName(generatorType, name),
      GeneratedCodeParent(generatorType, $"Domain{Kind}"));
  }
}
