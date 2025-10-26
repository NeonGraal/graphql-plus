namespace GqlPlus.Generating.Simple;

public class DomainNumberGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRange>
{
  internal override GenerateBaseDomain<IGqlpDomainRange> Generator { get; }
    = new DomainNumberGenerator();
}
