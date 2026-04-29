namespace GqlPlus.Generating.Simple;

public class DomainEnumInterfaceGeneratorTests
  : GenerateDomainTestsBase<IAstDomainLabel, EnumLabelInput>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IAstDomainLabel> Generator { get; }
    = new DomainEnumInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
  internal override GqlpBaseType BaseType => GqlpBaseType.Interface;

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override IAstDomainLabel MakeDomainItem(EnumLabelInput item)
    => A.ItemLabel(item.EnumType, item.Label);
}
