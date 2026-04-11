namespace GqlPlus.Generating.Simple;

public class DomainEnumInterfaceGeneratorTests
  : GenerateDomainTestsBase<IAstDomainLabel>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IAstDomainLabel> Generator { get; }
    = new DomainEnumInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
  internal override GqlpBaseType BaseType => GqlpBaseType.Interface;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public interface I" + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override IAstDomainLabel MakeDomainItem(string item)
    => A.ItemLabel("", item);
}
