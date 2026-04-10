using GqlPlus.Building.Schema.Simple;

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

  [Theory, RepeatData]
  public void GenerateType_WithoutParent_GeneratesDefaultParent(string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IGqlpDomain<TItem> type = A.Domain<TItem>(name, Kind).AsDomain;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent($"GqlpDomain{Kind}"));
  }

  protected override SimpleBuilder<IGqlpDomain<TItem>> MakeSimple(string name)
    => new DomainBuilder<TItem>(name, Kind);
  protected override void MakeItems(SimpleBuilder<IGqlpDomain<TItem>> builder, params string[] items)
    => ((DomainBuilder<TItem>)builder).WithItems([.. items.Select(MakeDomainItem)]);
  protected abstract TItem MakeDomainItem(string item);
}
