namespace GqlPlus.Generating.Simple;

public class DomainEnumGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainLabel>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IGqlpDomainLabel> Generator { get; }
    = new DomainEnumGenerator();

  protected override IGqlpDomainLabel MakeDomainItem(string item)
    => A.ItemLabel("", item);
}
