namespace GqlPlus.Encoding.Simple;

public class DomainRangeEncoderTests
  : DomainItemEncoderTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override IEncoder<DomainRangeModel> Encoder { get; }
    = new DomainRangeEncoder();

  protected override string[] ItemExpected(DomainRangeInput item, bool excluded, string description)
    => TagAll("_DomainRange",
        ":description=" + description.QuotedIdentifier(),
        ":exclude=" + excluded.TrueFalse(),
        $":from={item.Lower:0.#####}",
        $":to={item.Upper:0.#####}");

  protected override DomainRangeModel NewItem(DomainRangeInput item, bool excluded, string description)
    => new(item.Lower, item.Upper, excluded, description);
}

public class DomainItemRangeEncoderTests
  : DomainAllEncoderTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override string[] AllExpected(string name, DomainRangeInput item, string description)
    => TagAll("_DomainItem(_DomainRange)",
        ":domain=" + name,
        $":value=[_ItemModel]'{item}'");

  protected override DomainRangeModel NewItem(DomainRangeInput item, string description)
    => new(item.Lower, item.Upper, false, description);
}

public class DomainNumberEncoderTests
  : DomainEncoderTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Number;

  protected override DomainRangeModel NewItem(DomainRangeInput item) => new(item.Lower, item.Upper, false, "");

  protected override string ItemModel(DomainRangeInput item, string prefix)
    => $"{prefix}Model]'{item}'";
}
