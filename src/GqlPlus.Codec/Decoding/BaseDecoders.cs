namespace GqlPlus.Decoding;

internal abstract class DecoderBase<TModel>
  : IDecoder<TModel>
{
  private string? _tag;

  protected DecoderBase() { }

  protected DecoderBase(string tag)
    => _tag = tag;

  internal virtual string Tag => _tag ??= typeof(TModel).TypeTag();

  protected string TagMsg(string message)
    => $"Decoding {Tag}: {message}";

  protected IMessages Ok(TModel? _)
    => Messages.New;

  protected IMessages Mapped(object? input, TModel? output)
  {
    if (input is null) {
      return Messages.New.Add(TagMsg("Unable to map from null input").Error());
    }

    if (output is null) {
      return Messages.New.Add(TagMsg($"Unable to map from {input}").Error());
    }

    return Messages.New.Add(TagMsg($"Mapped {input} to {output}").Warning());
  }

  protected IMessages Parsed(object? input, TModel? output)
  {
    if (input is null) {
      return Messages.New.Add(TagMsg("Unable to parse from null input").Error());
    }

    if (output is null) {
      return Messages.New.Add(TagMsg($"Unable to parse from {input}").Error());
    }

    return Messages.New.Add(TagMsg($"Parsed {input} to {output}").Info());
  }

  protected IMessages DecodeClassList<T>(IEnumerable<IValue> list, IDecoder<T> decoder, out IEnumerable<T> output)
    where T : class
  {
    List<T> result = [];
    IMessages messages = Messages.New;
    foreach (IValue item in list) {
      messages.Add(decoder.Decode(item, out T? itemOutput));
      if (itemOutput is not null) {
        result.Add(itemOutput);
      }
    }

    output = result;
    return messages;
  }

  protected IMessages DecodeStructList<T>(IEnumerable<IValue> list, IDecoder<T?> decoder, out IEnumerable<T> output)
    where T : struct
  {
    List<T> result = [];
    IMessages messages = Messages.New;
    foreach (IValue item in list) {
      messages.Add(decoder.Decode(item, out T? itemOutput));
      if (itemOutput is not null) {
        result.Add(itemOutput.Value);
      }
    }

    output = result;
    return messages;
  }

  public abstract IMessages Decode(IValue input, out TModel? output);
}

internal class EnumDecoder<T>
  : DecoderBase<T?>
  where T : struct, Enum
{
  public EnumDecoder()
    : base(typeof(T).TypeTag())
  { }

  public override IMessages Decode(IValue input, out T? output)
  {
    output = null;
    IMessages messages = Messages.New;

    if (!string.IsNullOrWhiteSpace(input.Tag) && Tag != input.Tag) {
      return messages.Add(TagMsg($"Invalid tag {input.Tag}").Error());
    }

    if (input.TryGetNumber(out decimal? numValue)) {
      if (Enum.IsDefined(typeof(T), (int)numValue)) {
        output = (T)(object)(int)numValue;
      }

      return Mapped(numValue, output);
    }

    if (input.TryGetText(out string? strValue)) {
      if (Enum.TryParse(strValue, out T result)) {
        output = result;
        return messages;
      }

      return messages.Add(TagMsg($"Unable to parse {strValue}").Error());
    }

    if (input.TryGetList(out IEnumerable<IValue>? list)
        && list.Count() == 1) {
      return Decode(list.First(), out output);
    }

    return messages.Add(TagMsg($"Unable to decode {input}").Error());
  }
}

internal abstract class ScalarDecoder<TModel>
  : DecoderBase<TModel>
{
  public override IMessages Decode(IValue input, out TModel? output)
  {
    if (input.TryGetBoolean(out bool? boolValue)) {
      return DecodeBoolean(boolValue, out output);
    }

    if (input.TryGetNumber(out decimal? numValue)) {
      return DecodeNumber(numValue, out output);
    }

    if (input.TryGetText(out string? strValue)) {
      return DecodeText(strValue, out output);
    }

    if (input.TryGetList(out IEnumerable<IValue>? list)
        && list.Count() == 1) {
      return Decode(list.First(), out output);
    }

    output = default;
    return new Messages(TagMsg($"Unable to decode {input}").Error());
  }

  protected abstract IMessages DecodeBoolean(bool? boolValue, out TModel? output);
  protected abstract IMessages DecodeNumber(decimal? numValue, out TModel? output);
  protected abstract IMessages DecodeText(string strValue, out TModel? output);
}
