
namespace GqlPlus.Generating.Simple;

public class BooleanDomainGeneratorTests
  : DomainGeneratorTestBase<IGqlpDomainTrueFalse>
{
  internal override GenerateBaseDomain<IGqlpDomainTrueFalse> Generator { get; }
    = new BooleanDomainGenerator();
}
