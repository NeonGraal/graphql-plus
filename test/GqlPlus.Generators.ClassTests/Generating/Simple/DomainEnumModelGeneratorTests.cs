namespace GqlPlus.Generating.Simple;

public class DomainEnumModelGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainLabel>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IGqlpDomainLabel> Generator { get; }
    = new DomainEnumModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedImplementation("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedImplementation(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedImplementation(contains);

  protected override IGqlpDomainLabel MakeDomainItem(string item)
    => A.ItemLabel("", item);
}
