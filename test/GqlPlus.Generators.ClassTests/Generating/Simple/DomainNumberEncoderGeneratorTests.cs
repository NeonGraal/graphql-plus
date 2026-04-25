namespace GqlPlus.Generating.Simple;

public class DomainNumberEncoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRange>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IAstDomainRange> Generator { get; }
    = new DomainNumberEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("internal class " + TestPrefix + name + "Encoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IAstDomainRange MakeDomainItem(string item)
    => A.ItemRange(item?.Length ?? 0);
}
