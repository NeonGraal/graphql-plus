namespace GqlPlus.Generating.Simple;

public class DomainStringDecoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRegex, string>
{
  protected override DomainKind Kind => DomainKind.String;
  internal override GenerateBaseDomain<IAstDomainRegex> Generator { get; }
    = new DomainStringDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  protected override IAstDomainRegex MakeDomainItem(string item)
    => A.ItemRegex(item);
}
