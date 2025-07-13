namespace GqlPlus.Encoding.Simple;

public class DomainRegexEncoderTests
  : DomainItemEncoderTestBase<DomainRegexModel, string>
{
  protected override IEncoder<DomainRegexModel> Encoder { get; }
    = new DomainRegexEncoder();

  protected override string[] ItemExpected(string item, bool excluded)
    => ["!_DomainRegex",
        "exclude: " + excluded.TrueFalse(),
        "pattern: " + item
        ];
  protected override DomainRegexModel NewItem(string item, bool excluded) => new(item, excluded);
}

public class DomainStringEncoderTests
  : DomainEncoderTestBase<DomainRegexModel, string>
{
  protected override DomainKindModel DomainKind => DomainKindModel.String;

  protected override DomainRegexModel NewItem(string item) => new(item, false);
}
