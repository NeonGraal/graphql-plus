namespace GqlPlus.Generating.Simple;

public class DomainBooleanInterfaceGeneratorTests
  : GenerateDomainTestsBase<IAstDomainTrueFalse, bool>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IAstDomainTrueFalse> Generator { get; }
    = new DomainBooleanInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
  internal override GqlpBaseType BaseType => GqlpBaseType.Interface;

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override IAstDomainTrueFalse MakeDomainItem(bool item)
    => A.ItemTrueFalse(item);
}
