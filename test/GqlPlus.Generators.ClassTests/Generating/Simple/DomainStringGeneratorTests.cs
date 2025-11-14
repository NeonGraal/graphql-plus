namespace GqlPlus.Generating.Simple;

public class DomainStringGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRegex>
{
  protected override DomainKind Kind => DomainKind.String;
  internal override GenerateBaseDomain<IGqlpDomainRegex> Generator { get; }
    = new DomainStringGenerator();
}
