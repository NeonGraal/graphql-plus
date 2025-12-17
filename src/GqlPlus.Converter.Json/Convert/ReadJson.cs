namespace GqlPlus.Convert;

internal sealed class ReadJson
{
  internal string _keyTag = "";
  internal string _listTag = "";
  internal string _mapTag = "";
  internal string _valueTag = "";
  internal StructureValue? _value;
  internal Structured? _list;
  internal readonly Dictionary<StructureValue, Structured> Fields = [];

  private StructureValue? ReadValue(ref Utf8JsonReader reader)
  => reader.TokenType switch {
    JsonTokenType.Number => new(reader.GetDecimal()),
    JsonTokenType.False or JsonTokenType.True => new(reader.GetBoolean()),
    JsonTokenType.String or JsonTokenType.PropertyName => new(reader.GetString()),
    JsonTokenType.Null => new((string?)null),
    // JsonTokenType.Comment , 
    _ => null,
  };

  public KeyTagResult ReadStructured(ref Utf8JsonReader reader)
    => reader.TokenType switch {
      JsonTokenType.StartObject => ReadMap(ref reader),
      JsonTokenType.StartArray => new("", ReadList(ref reader)),
      _ => new("", new(ReadValue(ref reader))),
    };

  private KeyTagResult ReadMap(ref Utf8JsonReader reader)
  {
    while (reader.Read()) {
      if (reader.TokenType == JsonTokenType.EndObject) {
        break;
      }

      // Read the property name
      string propertyName = reader.GetString().IfWhiteSpace();
      reader.Read(); // Move to the value

      if (IsTag("keyTag")) {
        _keyTag = reader.GetString().IfWhiteSpace();
        continue;
      }

      if (IsTag("listTag")) {
        _listTag = reader.GetString().IfWhiteSpace();
        continue;
      }

      if (IsTag("mapTag")) {
        _mapTag = reader.GetString().IfWhiteSpace();
        continue;
      }

      if (IsTag("valueTag")) {
        _valueTag = reader.GetString().IfWhiteSpace();
        continue;
      }

      if (IsTag("value")) {
        _value = ReadValue(ref reader);
        continue;
      }

      if (IsTag("list")) {
        _list = ReadList(ref reader);
        continue;
      }

      KeyTagResult field = new ReadJson().ReadStructured(ref reader);

      Fields.Add(new(propertyName, field.KeyTag), field.Result);

      bool IsTag(string tagName)
        => propertyName.Equals("$" + tagName, StringComparison.Ordinal);
    }

    return Result();
  }

  internal KeyTagResult Result()
  {
    if (_value is not null) {
      _value.Tag = _valueTag;
      return new(_keyTag, new(_value));
    }

    if (_list is not null) {
      _list.Tag = _listTag;
      return new(_keyTag, _list);
    }

    return new(_keyTag, new(Fields, _mapTag));
  }

  private Structured ReadList(ref Utf8JsonReader reader)
  {
    List<Structured> items = [];
    while (reader.Read()) {
      if (reader.TokenType == JsonTokenType.EndArray) {
        break;
      }

      Structured? item = new ReadJson().ReadStructured(ref reader).Result;
      if (item is not null) {
        items.Add(item);
      }
    }

    return new(items);
  }
}

internal record struct KeyTagResult(string KeyTag, Structured Result);
