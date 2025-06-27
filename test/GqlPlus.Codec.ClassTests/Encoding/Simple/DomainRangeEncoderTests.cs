namespace GqlPlus.Encoding.Simple;

public class DomainRangeEncoderTests
  : DomainItemEncoderTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override IEncoder<DomainRangeModel> Encoder { get; }
    = new DomainRangeEncoder();

  protected override string[] ItemExpected(DomainRangeInput item, bool excluded)
    => ["!_DomainRange",
        "exclude: " + excluded.TrueFalse(),
        $"from: {item.Lower:0.#####}",
        $"to: {item.Upper:0.#####}"
        ];

  protected override DomainRangeModel NewItem(DomainRangeInput item, bool excluded) => new(item.Lower, item.Upper, excluded);
}

public class DomainItemRangeEncoderTests
  : DomainAllEncoderTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override string[] AllExpected(string name, DomainRangeInput item)
    => ["!_DomainItem(_DomainRange)",
        "domain: " + name,
        $"value: !_ItemModel '{item}'"
        ];

  protected override DomainRangeModel NewItem(DomainRangeInput item) => new(item.Lower, item.Upper, false);
}

public class DomainNumberEncoderTests
  : DomainEncoderTestBase<DomainRangeModel, DomainRangeInput>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Number;

  protected override DomainRangeModel NewItem(DomainRangeInput item) => new(item.Lower, item.Upper, false);
}
