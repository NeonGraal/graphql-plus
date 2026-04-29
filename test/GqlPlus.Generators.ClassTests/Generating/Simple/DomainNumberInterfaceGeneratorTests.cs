namespace GqlPlus.Generating.Simple;

public class DomainNumberInterfaceGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRange, DomainRangeInput>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IAstDomainRange> Generator { get; }
    = new DomainNumberInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
  internal override GqlpBaseType BaseType => GqlpBaseType.Interface;

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override IAstDomainRange MakeDomainItem(DomainRangeInput item)
    => A.ItemRange(item.Lower ?? item.Upper ?? 0);
}
