namespace GqlPlus.Encoding.Simple;

public class DomainTrueFalseEncoderTests
  : DomainItemEncoderTestBase<DomainTrueFalseModel, bool>
{
  protected override IEncoder<DomainTrueFalseModel> Encoder { get; }
    = new DomainTrueFalseEncoder();

  protected override string[] ItemExpected(bool item, bool excluded)
    => ["!_DomainTrueFalse",
        "exclude: " + excluded.TrueFalse(),
        "value: " + item.TrueFalse()
        ];
  protected override DomainTrueFalseModel NewItem(bool item, bool excluded) => new(item, excluded, "");
}

public class DomainBooleanEncoderTests
  : DomainEncoderTestBase<DomainTrueFalseModel, bool>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Boolean;

  protected override DomainTrueFalseModel NewItem(bool item) => new(item, false, "");
}
