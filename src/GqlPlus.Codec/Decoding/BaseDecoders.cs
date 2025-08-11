namespace GqlPlus.Decoding;

internal abstract class DecoderBase<TOutput>
  : IDecoder<TOutput>
{
  private string? _tag;

  protected DecoderBase() { }

  protected DecoderBase(string tag)
    => _tag = tag;

  internal virtual string Tag => _tag ??= typeof(TOutput).TypeTag();

  protected string TagMsg(string message)
    => $"Decoding {Tag}: {message}";

  protected virtual IMessages Ok(TOutput? _)
    => Messages.New;

  protected IMessages Error(string message, TOutput? _)
    => Messages.New.Add(TagMsg(message).Error());

  protected virtual IMessages Warning(string message, TOutput? _)
    => Messages.New.Add(TagMsg(message).Warning());

  protected IMessages Info(string message, TOutput? _)
    => Messages.New.Add(TagMsg(message).Info());

  protected IMessages Mapped(object? input, TOutput? output)
  {
    if (input is null) {
      return Error("Unable to map from null input", output);
    }

    if (output is null) {
      return Error($"Unable to map from {input}", output);
    }

    return Warning($"Mapped {input} to {output}", output);
  }

  protected IMessages Parsed(object? input, TOutput? output)
  {
    if (input is null) {
      return Error("Unable to parse from null input", output);
    }

    if (output is null) {
      return Error($"Unable to parse from {input}", output);
    }

    return Info($"Parsed {input} to {output}", output);
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

  public abstract IMessages Decode(IValue input, out TOutput? output);
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

    return Error($"Unable to decode {input}", output = default);
  }

  protected abstract IMessages DecodeBoolean(bool? boolValue, out TModel? output);
  protected abstract IMessages DecodeNumber(decimal? numValue, out TModel? output);
  protected abstract IMessages DecodeText(string strValue, out TModel? output);
}
