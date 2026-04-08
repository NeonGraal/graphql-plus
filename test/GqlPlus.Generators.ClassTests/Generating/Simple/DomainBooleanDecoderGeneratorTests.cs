namespace GqlPlus.Generating.Simple;

public class DomainBooleanDecoderGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainTrueFalse>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IGqlpDomainTrueFalse> Generator { get; }
    = new DomainBooleanDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedDecoder("internal class " + TestPrefix + name + "Decoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override IGqlpDomainTrueFalse MakeDomainItem(string item)
    => A.ItemTrueFalse(item?.Length % 2 == 1);
}
