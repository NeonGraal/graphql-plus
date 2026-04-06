namespace GqlPlus.Generating.Simple;

public class DomainStringInterfaceGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRegex>
{
  protected override DomainKind Kind => DomainKind.String;
  internal override GenerateBaseDomain<IGqlpDomainRegex> Generator { get; }
    = new DomainStringInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedImplementation(string contains)
    => _ => result => { };

  protected override IGqlpDomainRegex MakeDomainItem(string item)
    => A.ItemRegex(item);
}
