namespace GqlPlus.Generating.Simple;

public class DomainStringEncoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRegex>
{
  protected override DomainKind Kind => DomainKind.String;
  internal override GenerateBaseDomain<IAstDomainRegex> Generator { get; }
    = new DomainStringEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("internal class " + TestPrefix + name + "Encoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IAstDomainRegex MakeDomainItem(string item)
    => A.ItemRegex(item);
}
