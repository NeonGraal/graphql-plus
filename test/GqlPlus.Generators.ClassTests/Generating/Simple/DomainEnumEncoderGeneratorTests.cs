namespace GqlPlus.Generating.Simple;

public class DomainEnumEncoderGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainLabel>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IGqlpDomainLabel> Generator { get; }
    = new DomainEnumEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("internal class " + TestPrefix + name + "Encoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IGqlpDomainLabel MakeDomainItem(string item)
    => A.ItemLabel("", item);
}
