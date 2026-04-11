using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating.Simple;

public class DomainNumberInterfaceGeneratorTests
  : GenerateDomainTestsBase<IAstDomainRange>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IAstDomainRange> Generator { get; }
    = new DomainNumberInterfaceGenerator();
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

  protected override IAstDomainRange MakeDomainItem(string item)
    => A.ItemRange(item?.Length ?? 0);
}
