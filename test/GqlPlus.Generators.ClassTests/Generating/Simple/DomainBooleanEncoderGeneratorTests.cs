namespace GqlPlus.Generating.Simple;

public class DomainBooleanEncoderGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainTrueFalse>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IGqlpDomainTrueFalse> Generator { get; }
    = new DomainBooleanEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("internal class " + TestPrefix + name + "Encoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IGqlpDomainTrueFalse MakeDomainItem(string item)
    => A.ItemTrueFalse(item?.Length % 2 == 1);
}
