namespace GqlPlus.Generating.Simple;

public class DomainNumberModelGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRange, DomainRangeInput>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IAstDomainRange> Generator { get; }
    = new DomainNumberModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedModel("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedModel(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedModel(contains);

  protected override IAstDomainRange MakeDomainItem(DomainRangeInput item)
    => A.ItemRange(item.Lower ?? item.Upper ?? 0);
}
