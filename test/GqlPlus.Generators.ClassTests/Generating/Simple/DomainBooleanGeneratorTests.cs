namespace GqlPlus.Generating.Simple;

public class DomainBooleanGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainTrueFalse>
{
  internal override GenerateBaseDomain<IGqlpDomainTrueFalse> Generator { get; }
    = new DomainBooleanGenerator();
}
