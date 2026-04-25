namespace GqlPlus.Generating.Simple;

public class DomainBooleanDecoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainTrueFalse>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IAstDomainTrueFalse> Generator { get; }
    = new DomainBooleanDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedDecoder("internal class " + TestPrefix + name + "Decoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  protected override IAstDomainTrueFalse MakeDomainItem(string item)
    => A.ItemTrueFalse(item?.Length % 2 == 1);
}
