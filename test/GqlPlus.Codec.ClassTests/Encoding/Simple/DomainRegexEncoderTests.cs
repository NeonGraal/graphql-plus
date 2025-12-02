namespace GqlPlus.Encoding.Simple;

public class DomainRegexEncoderTests
  : DomainItemEncoderTestBase<DomainRegexModel, string>
{
  protected override IEncoder<DomainRegexModel> Encoder { get; }
    = new DomainRegexEncoder();

  protected override string[] ItemExpected(string item, bool excluded, string description)
    => ["!_DomainRegex",
        "description: " + description.QuotedIdentifier(),
        "exclude: " + excluded.TrueFalse(),
        "pattern: " + item
        ];
  protected override DomainRegexModel NewItem(string item, bool excluded, string description) => new(item, excluded, description);
}

public class DomainItemRegexEncoderTests
  : DomainAllEncoderTestBase<DomainRegexModel, string>
{
  protected override string[] AllExpected(string name, string item, string description)
    => ["!_DomainItem(_DomainRegex)",
        "domain: " + name,
        $"value: !_ItemModel " + item.QuotedIdentifier()
        ];

  protected override DomainRegexModel NewItem(string item, string description)
    => new(item, false, description);
}

public class DomainStringEncoderTests
  : DomainEncoderTestBase<DomainRegexModel, string>
{
  protected override DomainKindModel DomainKind => DomainKindModel.String;

  protected override DomainRegexModel NewItem(string item) => new(item, false, "");
}
