namespace GqlPlus.Generating.Simple;

public class DomainEnumGeneratorTests
  : DomainGeneratorTestBase<IGqlpDomainLabel>
{
  internal override GenerateBaseDomain<IGqlpDomainLabel> Generator { get; }
    = new DomainEnumGenerator();
}
