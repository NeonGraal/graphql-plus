namespace GqlPlus.Generating.Simple;

public class DomainBooleanModelGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainTrueFalse>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IGqlpDomainTrueFalse> Generator { get; }
    = new DomainBooleanModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedImplementation("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedImplementation(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedImplementation(contains);

  protected override IGqlpDomainTrueFalse MakeDomainItem(string item)
    => A.ItemTrueFalse(item?.Length % 2 == 1);
}
