namespace GqlPlus.Encoding.Simple;

public class DomainTrueFalseEncoderTests
  : DomainItemEncoderTestBase<DomainTrueFalseModel, bool>
{
  protected override IEncoder<DomainTrueFalseModel> Encoder { get; }
    = new DomainTrueFalseEncoder();

  protected override string[] ItemExpected(bool item, bool excluded, string description)
    => ["!_DomainTrueFalse",
        "description: " + description.Quoted("'"),
        "exclude: " + excluded.TrueFalse(),
        "value: " + item.TrueFalse()
        ];
  protected override DomainTrueFalseModel NewItem(bool item, bool excluded, string description) => new(item, excluded, description);
}

public class DomainBooleanEncoderTests
  : DomainEncoderTestBase<DomainTrueFalseModel, bool>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Boolean;

  protected override DomainTrueFalseModel NewItem(bool item) => new(item, false, "");
}
