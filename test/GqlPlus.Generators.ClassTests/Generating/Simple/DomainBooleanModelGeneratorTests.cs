namespace GqlPlus.Generating.Simple;

public class DomainBooleanModelGeneratorTests
  : GenerateDomainTestsBase<IAstDomainTrueFalse, bool>
{
  protected override DomainKind Kind => DomainKind.Boolean;
  internal override GenerateBaseDomain<IAstDomainTrueFalse> Generator { get; }
    = new DomainBooleanModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedModel("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedModel(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedModel(contains);

  protected override IAstDomainTrueFalse MakeDomainItem(bool item)
    => A.ItemTrueFalse(item);
}
