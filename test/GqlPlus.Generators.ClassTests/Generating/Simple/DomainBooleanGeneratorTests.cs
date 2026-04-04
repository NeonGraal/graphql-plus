namespace GqlPlus.Generating.Simple;

public class DomainBooleanGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainTrueFalse>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IGqlpDomainTrueFalse> Generator { get; }
    = new DomainBooleanInterfaceGenerator();

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedImplementation(string contains)
    => _ => result => { };

  protected override IGqlpDomainTrueFalse MakeDomainItem(string item)
    => A.ItemTrueFalse(item?.Length % 2 == 1);
}
