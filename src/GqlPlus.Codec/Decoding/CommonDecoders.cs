namespace GqlPlus.Decoding;

internal class BooleanDecoder
  : ScalarDecoder<bool?>
{
  protected override bool? DecodeBoolean(bool? boolValue) => boolValue;
  protected override bool? DecodeNumber(decimal? numValue)
    => numValue switch {
      0m => false,
      1m => true,
      _ => null
    };
  protected override bool? DecodeText(string strValue)
    => strValue switch {
      "true" => true,
      "false" => false,
      _ => null
    };
}

internal class ConstantDecoder
  : IDecoder<ConstantModel>
{
  public ConstantModel? Decode(IValue value)
  {
    if (value.TryGetBoolean(out bool? boolValue)) {
      return new(new SimpleModel(boolValue));
    }

    if (value.TryGetNumber(out decimal? numValue)) {
      return new(new SimpleModel(numValue));
    }

    if (value.TryGetText(out string? strValue)) {
      return new(new SimpleModel(strValue));
    }

    if (value.TryGetList(out IEnumerable<IValue>? list)) {
      return new(list.Select(Decode).OfType<ConstantModel>());
    }

    if (value.TryGetMap(out IMap<IValue>? map)) {
      Dictionary<SimpleModel, ConstantModel> dict = map
        .Select(kv => new KeyValuePair<SimpleModel, ConstantModel?>(new SimpleModel(kv.Key), Decode(kv.Value)))
        .Where(kv => kv.Value != null)
        .ToDictionary(k => k.Key, v => v.Value!);
      return new(dict);
    }

    return default;
  }
}

internal class NumberDecoder
  : ScalarDecoder<decimal?>
{
  protected override decimal? DecodeBoolean(bool? boolValue) => boolValue is null ? null : boolValue == true ? 1m : 0m;
  protected override decimal? DecodeNumber(decimal? numValue) => numValue;
  protected override decimal? DecodeText(string strValue) => decimal.TryParse(strValue, out decimal result) ? result : null;
}

internal class SimpleDecoder
  : ScalarDecoder<SimpleModel>
{
  protected override SimpleModel? DecodeBoolean(bool? boolValue) => new(boolValue);
  protected override SimpleModel? DecodeNumber(decimal? numValue) => new(numValue);
  protected override SimpleModel? DecodeText(string strValue) => new(strValue);
}

internal class StringDecoder
  : ScalarDecoder<string>
{
  protected override string? DecodeBoolean(bool? boolValue) => boolValue.TrueFalse();
  protected override string? DecodeNumber(decimal? numValue) => $"{numValue:0.#####}";
  protected override string? DecodeText(string strValue) => strValue;
}
