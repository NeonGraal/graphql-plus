namespace GqlPlus.Decoding;

internal class BooleanDecoder
  : ScalarDecoder<bool?>
{
  protected override IMessages DecodeBoolean(bool? boolValue, out bool? output)
    => Ok(output = boolValue);

  protected override IMessages DecodeNumber(decimal? numValue, out bool? output)
    => Mapped(numValue, output = numValue switch {
      0m => false,
      1m => true,
      _ => null
    });

  protected override IMessages DecodeText(string strValue, out bool? output)
    => Parsed(strValue, output = strValue switch {
      BuiltIn.BooleanTrue => true,
      BuiltIn.BooleanFalse => false,
      _ => null
    });
}

internal class ConstantDecoder
  : DecoderBase<ConstantModel>
{
  public override IMessages Decode(IValue input, out ConstantModel? output)
  {
    if (input.TryGetBoolean(out bool? boolValue)) {
      return Ok(output = new(new SimpleModel(boolValue)));
    }

    if (input.TryGetNumber(out decimal? numValue)) {
      return Ok(output = new(new SimpleModel(numValue)));
    }

    if (input.TryGetText(out string? strValue)) {
      return Ok(output = new(new SimpleModel(strValue)));
    }

    if (input.TryGetList(out IEnumerable<IValue>? list)) {
      return DecodeConstantList(list, out output);
    }

    if (input.TryGetMap(out IMap<IValue>? map)) {
      return DecodeConstantMap(map, out output);
    }

    output = null;
    return new Messages(TagMsg($"Unable to decode {input}").Error());
  }

  private IMessages DecodeConstantMap(IMap<IValue> map, out ConstantModel? output)
  {
    IMessages messages = Messages.New;
    Dictionary<SimpleModel, ConstantModel> dict = [];

    foreach (string key in map.Keys) {
      messages.Add(Decode(map[key], out ConstantModel? result));
      if (result is not null) {
        dict.Add(new SimpleModel(key), result);
      }
    }

    if (dict.Count > 0) {
      output = new(dict);
    } else {
      output = null;
      messages.Add(TagMsg($"Unable to decode map {map}").Error());
    }

    return messages;
  }

  private IMessages DecodeConstantList(IEnumerable<IValue> list, out ConstantModel? output)
  {
    IMessages messages = DecodeClassList(list, this, out IEnumerable<ConstantModel>? result);
    if (result?.Count() > 0) {
      output = new(result);
    } else {
      output = null;
      messages.Add(TagMsg($"Unable to decode list {list}").Error());
    }

    return messages;
  }
}

internal class NumberDecoder
  : ScalarDecoder<decimal?>
{
  protected override IMessages DecodeBoolean(bool? boolValue, out decimal? output)
    => Mapped(boolValue, output = boolValue is null ? null : boolValue == true ? 1m : 0m);
  protected override IMessages DecodeNumber(decimal? numValue, out decimal? output)
    => Ok(output = numValue);
  protected override IMessages DecodeText(string strValue, out decimal? output)
    => Parsed(strValue, output = decimal.TryParse(strValue, out decimal result) ? result : null);
}

internal class SimpleDecoder
  : ScalarDecoder<SimpleModel>
{
  protected override IMessages DecodeBoolean(bool? boolValue, out SimpleModel? output)
    => Ok(output = new(boolValue));
  protected override IMessages DecodeNumber(decimal? numValue, out SimpleModel? output)
    => Ok(output = new(numValue));
  protected override IMessages DecodeText(string strValue, out SimpleModel? output)
    => Ok(output = new(strValue));
}

internal class StringDecoder
  : ScalarDecoder<string>
{
  protected override IMessages DecodeBoolean(bool? boolValue, out string? output)
    => Ok(output = boolValue?.TrueFalse());
  protected override IMessages DecodeNumber(decimal? numValue, out string? output)
    => Ok(output = $"{numValue:0.#####}");
  protected override IMessages DecodeText(string strValue, out string? output)
    => Ok(output = strValue);
}
