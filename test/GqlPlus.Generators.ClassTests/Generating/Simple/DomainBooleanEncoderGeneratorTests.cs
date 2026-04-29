namespace GqlPlus.Generating.Simple;

public class DomainBooleanEncoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainTrueFalse, bool>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IAstDomainTrueFalse> Generator { get; }
    = new DomainBooleanEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IAstDomainTrueFalse MakeDomainItem(bool item)
    => A.ItemTrueFalse(item);
}
