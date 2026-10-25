namespace GqlPlus.Decoding;

public abstract class ScalarDecoderClassTestBase<TModel, TInput>
  : DecoderClassTestBase<TModel>
{
  public string BoolMapped { get; protected set; } = "";

  [Theory, RepeatData]
  public void Decode_Bool(bool value)
    => DecodeAndCheck(new ScalarValue(value), ExpectedBool(value), BoolMapped);

  [Theory, RepeatData]
  public void Decode_Number(decimal value)
    => DecodeAndCheck(new ScalarValue(value), ExpectedNumber(value));

  [Theory, RepeatData, InlineData("")]
  public void Decode_Text(string value)
    => DecodeAndCheck(new ScalarValue(value), ExpectedText(value));

  [Theory, RepeatData]
  public void Decode_List(TInput value)
    => DecodeAndCheck(DecoderTestValue.FromList([Value(value)]), ExpectedList(value));

  [Theory, RepeatData, RepeatInlineData("")]
  public void Decode_Dict(string key, TInput value)
    => DecodeAndCheck(DecoderTestValue.FromMap([new(key, Value(value))]), ExpectedDict(key, value));

  protected abstract IValue Value(TInput value);

  protected abstract TModel? ExpectedBool(bool value);
  protected abstract TModel? ExpectedNumber(decimal value);
  protected abstract TModel? ExpectedText(string value);
  protected abstract TModel? ExpectedList(TInput value);
  protected abstract TModel? ExpectedDict(string key, TInput value);
}

public abstract class ScalarDecoderClassTestBase<TModel>
  : ScalarDecoderClassTestBase<TModel, string>
{
  protected sealed override IValue Value(string value) => new ScalarValue(value);

}
