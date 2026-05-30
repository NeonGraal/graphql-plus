namespace GqlPlus.Encoding;

public class OpSelectionEncoderTests
  : EncoderClassTestBase<OpSelectionModel>
{
  public OpSelectionEncoderTests()
  {
    _argument = RFor<OpArgumentModel>();
    _directive = RFor<DirectiveModel>();
    _modifier = RFor<ModifierModel>();
    _type = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository repo = A.Of<IEncoderRepository>();
    repo.EncoderForReturns(_argument);
    repo.EncoderForReturns(_directive);
    repo.EncoderForReturns(_modifier);
    repo.EncoderForReturns(_type);
    Encoder = new OpSelectionEncoder(repo);
  }

  private readonly IEncoder<OpArgumentModel> _argument;
  private readonly IEncoder<DirectiveModel> _directive;
  private readonly IEncoder<ModifierModel> _modifier;
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _type;

  protected override IEncoder<OpSelectionModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithFieldSelectionModel_ReturnsStructured(string field)
  {
    EncodeAndCheck(new OpFieldSelectionModel(field, string.Empty), [
        $"[_OpFieldSelection]:name={field}",
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithInlineSelectionModel_ReturnsStructured(string type)
  {
    EncodeAndCheck(new OpInlineSelectionModel(new TypeRefModel<TypeKindModel>(TypeKindModel.Output, type, ""), string.Empty),
      ["=[_OpInlineSelection]"]);
  }

  [Theory, RepeatData]
  public void Encode_WithSpreadSelectionModel_ReturnsStructured(string fragment)
  {
    EncodeAndCheck(new OpSpreadSelectionModel(fragment, string.Empty),
      [$"[_OpSpreadSelection]:fragment={fragment}"]);
  }
}
