namespace GqlPlus.Generating.Simple;

public class DomainNumberDecoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRange, DomainRangeInput>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IAstDomainRange> Generator { get; }
    = new DomainNumberDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  protected override IAstDomainRange MakeDomainItem(DomainRangeInput item)
    => A.ItemRange(item.Lower ?? item.Upper ?? 0);
}
