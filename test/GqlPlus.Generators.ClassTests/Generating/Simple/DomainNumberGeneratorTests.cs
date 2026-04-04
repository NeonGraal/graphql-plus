namespace GqlPlus.Generating.Simple;

public class DomainNumberGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRange>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IGqlpDomainRange> Generator { get; }
    = new DomainNumberInterfaceGenerator();

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedImplementation(string contains)
    => _ => result => { };

  protected override IGqlpDomainRange MakeDomainItem(string item)
    => A.ItemRange(item?.Length ?? 0);
}
