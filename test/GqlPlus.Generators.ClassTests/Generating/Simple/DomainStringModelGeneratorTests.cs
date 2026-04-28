namespace GqlPlus.Generating.Simple;

public class DomainStringModelGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRegex, string>
{
  protected override DomainKind Kind => DomainKind.String;
  internal override GenerateBaseDomain<IAstDomainRegex> Generator { get; }
    = new DomainStringModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedModel("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedModel(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedModel(contains);

  protected override IAstDomainRegex MakeDomainItem(string item)
    => A.ItemRegex(item);
}
