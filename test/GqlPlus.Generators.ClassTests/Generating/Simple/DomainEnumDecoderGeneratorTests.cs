namespace GqlPlus.Generating.Simple;

public class DomainEnumDecoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainLabel, EnumLabelInput>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IAstDomainLabel> Generator { get; }
    = new DomainEnumDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedDecoder("internal class " + TestPrefix + name + "Decoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  protected override IAstDomainLabel MakeDomainItem(EnumLabelInput item)
    => A.ItemLabel(item.EnumType, item.Label);
}
