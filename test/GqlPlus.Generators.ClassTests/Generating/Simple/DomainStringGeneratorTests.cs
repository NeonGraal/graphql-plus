namespace GqlPlus.Generating.Simple;

public class DomainStringGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRegex>
{
  internal override GenerateBaseDomain<IGqlpDomainRegex> Generator { get; }
    = new DomainStringGenerator();
}
