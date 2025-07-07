namespace GqlPlus.Decoding;

internal abstract class DecoderBase<T>
  : IDecoder<T>
{
  private string? _tag;

  protected DecoderBase() { }

  protected DecoderBase(string tag)
    => _tag = tag;

  internal virtual string Tag => _tag ??= typeof(T).TypeTag();

  protected IMessage Err(string message)
    => $"Error decoding {Tag}: {message}".Error();
  protected IMessage Warn(string message)
    => $"Warning decoding {Tag}: {message}".Warning();

  protected IMessages Ok(T? _)
    => Messages.New;

  protected IMessages Mapped(object? input, T? output)
  {
    if (input is null) {
      return Messages.New.Add(Err($"Unable to map from null input"));
    }

    if (output is null) {
      return Messages.New.Add(Err($"Unable to map from {input}"));
    }

    return Messages.New.Add(Warn($"Mapped {input} to {output}"));
  }

  protected IMessages Parsed(object? input, T? output)
  {
    if (input is null) {
      return Messages.New.Add(Err($"Unable to parse from null input"));
    }

    if (output is null) {
      return Messages.New.Add(Err($"Unable to parse from {input}"));
    }

    return Messages.New.Add(Warn($"Parsed {input} to {output}"));
  }

  protected IMessages DecodeList<TR>(IEnumerable<IValue> list, IDecoder<TR> decoder, out IEnumerable<TR> output)
  {
    List<TR> result = [];
    IMessages messages = Messages.New;
    foreach (IValue item in list) {
      messages.Add(decoder.Decode(item, out TR? itemOutput));
      if (itemOutput is not null) {
        result.Add(itemOutput);
      }
    }

    output = result;
    return messages;
  }

  public abstract IMessages Decode(IValue input, out T? output);
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
      return messages.Add(Err($"Invalid tag {input.Tag}"));
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

      return messages.Add(Err($"Unable to parse {strValue}"));
    }

    if (input.TryGetList(out IEnumerable<IValue>? list)
        && list.Count() == 1) {
      return Decode(list.First(), out output);
    }

    return messages.Add(Err($"Unable to decode {input}"));
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
    return new Messages(Err($"Unable to decode {input}"));
  }

  protected abstract IMessages DecodeBoolean(bool? boolValue, out TModel? output);
  protected abstract IMessages DecodeNumber(decimal? numValue, out TModel? output);
  protected abstract IMessages DecodeText(string strValue, out TModel? output);
}
