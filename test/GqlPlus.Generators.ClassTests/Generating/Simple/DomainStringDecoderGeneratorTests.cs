namespace GqlPlus.Generating.Simple;

public class DomainStringDecoderGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRegex>
{
  protected override DomainKind Kind => DomainKind.String;
  internal override GenerateBaseDomain<IGqlpDomainRegex> Generator { get; }
    = new DomainStringDecoderGenerator();
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

  protected override IGqlpDomainRegex MakeDomainItem(string item)
    => A.ItemRegex(item);
}
