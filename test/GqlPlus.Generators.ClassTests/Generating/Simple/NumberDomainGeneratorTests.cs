
namespace GqlPlus.Generating.Simple;

public class NumberDomainGeneratorTests
  : DomainGeneratorTestBase<IGqlpDomainRange>
{
  internal override GenerateBaseDomain<IGqlpDomainRange> Generator { get; }
    = new NumberDomainGenerator();
}
