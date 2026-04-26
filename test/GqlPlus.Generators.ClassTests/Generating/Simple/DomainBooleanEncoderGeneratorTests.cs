namespace GqlPlus.Generating.Simple;

public class DomainBooleanEncoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainTrueFalse>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IAstDomainTrueFalse> Generator { get; }
    = new DomainBooleanEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("internal class " + TestPrefix + name + "Encoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IAstDomainTrueFalse MakeDomainItem(string item)
    => A.ItemTrueFalse(item?.Length % 2 == 1);
}
