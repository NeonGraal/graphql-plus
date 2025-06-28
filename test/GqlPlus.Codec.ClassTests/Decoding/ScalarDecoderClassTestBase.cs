namespace GqlPlus.Decoding;

public abstract class ScalarDecoderClassTestBase<TModel, TInput>
  : DecoderClassTestBase<TModel>
{
  [Theory, RepeatData]
  public void Decode_Bool(bool value)
    => DecodeAndCheck(new(value), ExpectedBool(value));
  [Theory, RepeatData]
  public void Decode_Number(decimal value)
    => DecodeAndCheck(new(value), ExpectedNumber(value));

  [Theory, RepeatData]
  public void Decode_Text(string value)
    => DecodeAndCheck(new(value), ExpectedText(value));

  [Theory, RepeatData]
  public void Decode_List(TInput value)
    => DecodeAndCheck(new([Value(value)]), ExpectedList(value));

  [Theory, RepeatData]
  public void Decode_Dict(string key, TInput value)
  {
    Map<TInput> map = new() { [key] = value };
    Structured input = map.Encode(Value);

    DecodeAndCheck(input, ExpectedDict(key, value));
  }

  protected abstract Structured Value(TInput value);

  protected abstract TModel? ExpectedBool(bool value);
  protected abstract TModel? ExpectedNumber(decimal value);
  protected abstract TModel? ExpectedText(string value);
  protected abstract TModel? ExpectedList(TInput value);
  protected abstract TModel? ExpectedDict(string key, TInput value);
}

public abstract class ScalarDecoderClassTestBase<TModel>
  : ScalarDecoderClassTestBase<TModel, string>
{
  protected sealed override Structured Value(string value) => new(value);
}
