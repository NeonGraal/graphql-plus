namespace GqlPlus.Generating.Simple;

public class DomainNumberGeneratorTests
  : DomainGeneratorTestBase<IGqlpDomainRange>
{
  internal override GenerateBaseDomain<IGqlpDomainRange> Generator { get; }
    = new DomainNumberGenerator();
}
