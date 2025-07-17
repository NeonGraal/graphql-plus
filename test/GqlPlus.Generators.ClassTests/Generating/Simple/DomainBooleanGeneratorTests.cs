namespace GqlPlus.Generating.Simple;

public class DomainBooleanGeneratorTests
  : DomainGeneratorTestBase<IGqlpDomainTrueFalse>
{
  internal override GenerateBaseDomain<IGqlpDomainTrueFalse> Generator { get; }
    = new DomainBooleanGenerator();
}
