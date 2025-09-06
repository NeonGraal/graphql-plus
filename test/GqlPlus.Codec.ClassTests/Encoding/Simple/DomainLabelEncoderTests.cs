namespace GqlPlus.Encoding.Simple;

public class DomainLabelEncoderTests
  : DomainItemEncoderTestBase<DomainLabelModel, EnumLabelInput>
{
  private readonly IEncoder<EnumValueModel> _enumValueEncoder;

  public DomainLabelEncoderTests()
  {
    _enumValueEncoder = RFor<EnumValueModel>();
    Encoder = new DomainLabelEncoder(_enumValueEncoder);
  }

  protected override IEncoder<DomainLabelModel> Encoder { get; }

  protected override string[] ItemExpected(EnumLabelInput item, bool excluded)
    => ["!_DomainLabel",
        "exclude: " + excluded.TrueFalse(),
        "value:",
        $"  value: !_EnumValue '{item}'",
        ];
  protected override DomainLabelModel NewItem(EnumLabelInput item, bool excluded)
  {
    EncodeReturnsMap(_enumValueEncoder, "_EnumValue", item);
    return new(item.EnumType, item.Label, excluded, "");
  }
}

public class DomainItemLabelEncoderTests
  : DomainAllEncoderTestBase<DomainLabelModel, EnumLabelInput>
{
  protected override string[] AllExpected(string name, EnumLabelInput item)
    => ["!_DomainItem(_DomainLabel)",
        "domain: " + name,
        $"value: !_ItemModel '{item}'",
        ];
  protected override DomainLabelModel NewItem(EnumLabelInput item) => new(item.EnumType, item.Label, false, "");
}

public class DomainEnumEncoderTests
  : DomainEncoderTestBase<DomainLabelModel, string>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Enum;

  protected override DomainLabelModel NewItem(string item) => new(item, "", false, "");
}
