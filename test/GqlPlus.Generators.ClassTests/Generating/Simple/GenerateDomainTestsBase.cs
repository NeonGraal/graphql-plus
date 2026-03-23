using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public abstract class GenerateDomainTestsBase<TItem>
  : GenerateSimpleTestsBase<IGqlpDomain<TItem>>
  where TItem : class, IGqlpDomainItem
{
  internal abstract GenerateBaseDomain<TItem> Generator { get; }
  protected abstract DomainKind Kind { get; }

  internal override GenerateForType<IGqlpDomain<TItem>> TypeGenerator => Generator;

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithoutParent_GeneratesDefaultParent(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
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
