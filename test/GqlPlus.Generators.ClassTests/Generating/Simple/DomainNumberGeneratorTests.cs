namespace GqlPlus.Generating.Simple;

public class DomainNumberGeneratorTests
  : GenerateDomainTestsBase<IGqlpDomainRange>
{
  protected override DomainKind Kind => DomainKind.Number;
  internal override GenerateBaseDomain<IGqlpDomainRange> Generator { get; }
    = new DomainNumberGenerator();

  protected override IGqlpDomainRange MakeDomainItem(string item)
    => A.ItemRange(item?.Length ?? 0);
}
