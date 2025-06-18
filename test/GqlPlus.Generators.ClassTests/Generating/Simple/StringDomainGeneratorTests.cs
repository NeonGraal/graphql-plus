
namespace GqlPlus.Generating.Simple;

public class StringDomainGeneratorTests
  : DomainGeneratorTestBase<IGqlpDomainRegex>
{
  internal override GenerateBaseDomain<IGqlpDomainRegex> Generator { get; }
    = new StringDomainGenerator();
}
