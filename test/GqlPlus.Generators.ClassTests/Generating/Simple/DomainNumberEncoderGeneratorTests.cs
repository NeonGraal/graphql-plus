namespace GqlPlus.Generating.Simple;

public class DomainNumberEncoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRange, DomainRangeInput>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IAstDomainRange> Generator { get; }
    = new DomainNumberEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IAstDomainRange MakeDomainItem(DomainRangeInput item)
    => A.ItemRange(item.Lower ?? item.Upper ?? 0);
}
