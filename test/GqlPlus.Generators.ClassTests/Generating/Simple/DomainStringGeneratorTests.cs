namespace GqlPlus.Generating.Simple;

public class DomainStringGeneratorTests
  : DomainGeneratorTestBase<IGqlpDomainRegex>
{
  internal override GenerateBaseDomain<IGqlpDomainRegex> Generator { get; }
    = new DomainStringGenerator();
}
