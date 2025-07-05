namespace GqlPlus.Decoding;

internal class EnumDecoder<T>
  : IDecoder<T>
  where T : struct, Enum
{
  private string? _tag;

  internal virtual string Tag => _tag ??= typeof(T).TypeTag();

  public T Decode(IValue value)
  {
    if (!string.IsNullOrWhiteSpace(value.Tag) && Tag != value.Tag) {
      return default;
    }

    if (value.TryGetNumber(out decimal? numValue) && Enum.IsDefined(typeof(T), (int)numValue)) {
      return (T)(object)(int)numValue;
    }

    if (value.TryGetText(out string? strValue) && Enum.TryParse(strValue, out T result)) {
      return result;
    }

    if (value.TryGetList(out IEnumerable<IValue>? list)
        && list.Count() == 1) {
      return Decode(list.First());
    }

    return default;
  }
}

internal abstract class ScalarDecoder<TModel>
  : IDecoder<TModel>
{
  public TModel? Decode(IValue value)
  {
    if (value.TryGetBoolean(out bool? boolValue)) {
      return DecodeBoolean(boolValue);
    }

    if (value.TryGetNumber(out decimal? numValue)) {
      return DecodeNumber(numValue);
    }

    if (value.TryGetText(out string? strValue)) {
      return DecodeText(strValue);
    }

    if (value.TryGetList(out IEnumerable<IValue>? list)
        && list.Count() == 1) {
      return Decode(list.First());
    }

    return default;
  }

  protected abstract TModel? DecodeBoolean(bool? boolValue);
  protected abstract TModel? DecodeNumber(decimal? numValue);
  protected abstract TModel? DecodeText(string strValue);
}
