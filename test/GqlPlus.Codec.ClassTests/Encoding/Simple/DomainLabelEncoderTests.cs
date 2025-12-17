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

  protected override string[] ItemExpected(EnumLabelInput item, bool excluded, string description)
    => TagAll("_DomainLabel",
        ":description=" + description.QuotedIdentifier(),
        ":exclude=" + excluded.TrueFalse(),
        $":value:value=[_EnumValue]'{item}'");

  protected override DomainLabelModel NewItem(EnumLabelInput item, bool excluded, string description)
  {
    EncodeReturnsMap(_enumValueEncoder, "_EnumValue", item);
    return new(item.EnumType, item.Label, excluded, description);
  }
}

public class DomainItemLabelEncoderTests
  : DomainAllEncoderTestBase<DomainLabelModel, EnumLabelInput>
{
  protected override string[] AllExpected(string name, EnumLabelInput item, string description)
    => TagAll("_DomainItem(_DomainLabel)",
        ":domain=" + name,
        $":value=[_ItemModel]'{item}'");
  protected override DomainLabelModel NewItem(EnumLabelInput item, string description)
    => new(item.EnumType, item.Label, false, description);
}

public class DomainEnumEncoderTests
  : DomainEncoderTestBase<DomainLabelModel, string>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Enum;

  protected override DomainLabelModel NewItem(string item) => new(item, "", false, "");
}
