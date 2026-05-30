namespace GqlPlus.Encoding;

public class OperationEncoderTests
  : EncoderClassTestBase<OperationModel>
{
  private readonly IEncoder<OpDirectiveModel> _directives;
  private readonly IEncoder<OpFragmentModel> _fragments;
  private readonly IEncoder<ModifierModel> _modifiers;
  private readonly IEncoder<OpResultModel> _result;
  private readonly IEncoder<OpSelectionModel> _selections;
  private readonly IEncoder<OpVariableModel> _variables;

  public OperationEncoderTests()
  {
    _directives = RFor<OpDirectiveModel>();
    _fragments = RFor<OpFragmentModel>();
    _modifiers = RFor<ModifierModel>();
    _result = RFor<OpResultModel>();
    _selections = RFor<OpSelectionModel>();
    _variables = RFor<OpVariableModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_directives);
    encoders.EncoderForReturns(_fragments);
    encoders.EncoderForReturns(_modifiers);
    encoders.EncoderForReturns(_result);
    encoders.EncoderForReturns(_selections);
    encoders.EncoderForReturns(_variables);
    Encoder = new OperationEncoder(encoders);
  }

  protected override IEncoder<OperationModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidOperationModel_ReturnsStructured(string name, string category)
  {
    // Act
    EncodeAndCheck(new(name, category, string.Empty), [
        "[_Operation]:category=" + category,
        "[_Operation]:name=" + name,
      ]);
  }
}
