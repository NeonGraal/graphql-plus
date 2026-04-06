namespace GqlPlus.Generating.Simple;

public class DomainNumberModelGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRange>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IGqlpDomainRange> Generator { get; }
    = new DomainNumberModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedImplementation("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedImplementation(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedImplementation(contains);

  protected override IGqlpDomainRange MakeDomainItem(string item)
    => A.ItemRange(item?.Length ?? 0);
}
