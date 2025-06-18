
namespace GqlPlus.Generating.Simple;

public class EnumDomainGeneratorTests
  : DomainGeneratorTestBase<IGqlpDomainLabel>
{
  internal override GenerateBaseDomain<IGqlpDomainLabel> Generator { get; }
    = new EnumDomainGenerator();
}
