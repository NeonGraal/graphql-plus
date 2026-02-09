namespace GqlPlus.Convert;

internal sealed class ReadJson
{
  private string _keyTag = "";
  private string _listTag = "";
  private string _mapTag = "";
  private string _valueTag = "";
  private StructureValue? _value;
  private Structured? _list;
  private readonly Dictionary<StructureValue, Structured> _fields = [];

  private delegate void ReadAction(ref Utf8JsonReader reader);
  private readonly Map<ReadAction> _tagActions;
  public ReadJson()
    => _tagActions = new()
    {
      { "$keyTag", (ref reader) => _keyTag = reader.GetString().IfWhiteSpace() },
      { "$listTag", (ref reader) => _listTag = reader.GetString().IfWhiteSpace() },
      { "$mapTag", (ref reader) => _mapTag = reader.GetString().IfWhiteSpace() },
      { "$valueTag", (ref reader) => _valueTag = reader.GetString().IfWhiteSpace() },
      { "$value", (ref reader) => _value = ReadValue(ref reader) },
      { "$list", (ref reader) => _list = ReadList(ref reader) },
    };

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

      if (_tagActions.TryGetValue(propertyName, out ReadAction? action)) {
        action(ref reader);
        continue;
      }

      KeyTagResult field = new ReadJson().ReadStructured(ref reader);

      _fields.Add(new(propertyName, field.KeyTag), field.Result);
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

    return new(_keyTag, new(_fields, _mapTag));
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
