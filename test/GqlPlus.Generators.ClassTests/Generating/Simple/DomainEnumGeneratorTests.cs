namespace GqlPlus.Generating.Simple;

public class DomainEnumGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainLabel>
{
  internal override GenerateBaseDomain<IGqlpDomainLabel> Generator { get; }
    = new DomainEnumGenerator();
}
