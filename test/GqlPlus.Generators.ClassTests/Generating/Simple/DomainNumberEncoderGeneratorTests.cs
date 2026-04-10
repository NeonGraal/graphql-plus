namespace GqlPlus.Generating.Simple;

public class DomainNumberEncoderGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRange>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IGqlpDomainRange> Generator { get; }
    = new DomainNumberEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEncoder("internal class " + TestPrefix + name + "Encoder");

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IGqlpDomainRange MakeDomainItem(string item)
    => A.ItemRange(item?.Length ?? 0);
}
