namespace GqlPlus.Convert;

internal sealed class ReadJson
{
  private string _keyTag = "";
  private string _listTag = "";
  private string _mapTag = "";
  private string _valueTag = "";
  private IGqlpValue? _value;
  private GqlpList? _list;
  private readonly List<KeyValuePair<IGqlpScalar, IGqlpValue>> _fields = [];

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

  private IGqlpValue? ReadValue(ref Utf8JsonReader reader)
    => reader.TokenType switch {
      JsonTokenType.Number => new GqlpScalar(reader.GetDecimal()),
      JsonTokenType.False or JsonTokenType.True => new GqlpScalar(reader.GetBoolean()),
      JsonTokenType.String or JsonTokenType.PropertyName => new GqlpScalar(reader.GetString() ?? "", isIdentifier: (reader.GetString() ?? "").IsIdentifier()),
      JsonTokenType.Null => new GqlpUnit(""),
      _ => null,
    };

  public KeyTagResult ReadStructured(ref Utf8JsonReader reader)
    => reader.TokenType switch {
      JsonTokenType.StartObject => ReadMap(ref reader),
      JsonTokenType.StartArray => new("", ReadList(ref reader)),
      _ => new("", ReadValue(ref reader) ?? new GqlpUnit()),
    };

  private KeyTagResult ReadMap(ref Utf8JsonReader reader)
  {
    while (reader.Read()) {
      if (reader.TokenType == JsonTokenType.EndObject) {
        break;
      }

      string propertyName = reader.GetString().IfWhiteSpace();
      reader.Read();

      if (_tagActions.TryGetValue(propertyName, out ReadAction? action)) {
        action(ref reader);
        continue;
      }

      KeyTagResult field = new ReadJson().ReadStructured(ref reader);
      _fields.Add(new(
        new GqlpScalar(propertyName, field.KeyTag, isIdentifier: propertyName.IsIdentifier()),
        field.Result));
    }

    return Result();
  }

  internal KeyTagResult Result()
  {
    if (_value is GqlpScalar scalar) {
      IGqlpValue taggedValue = scalar.Kind switch {
        GqlpScalarKind.Boolean => new GqlpScalar(scalar.BooleanValue!.Value, _valueTag),
        GqlpScalarKind.Number => new GqlpScalar(scalar.Number!.Value, _valueTag),
        _ => new GqlpScalar(scalar.Text ?? "", _valueTag, scalar.Kind == GqlpScalarKind.Identifier),
      };
      return new(_keyTag, taggedValue);
    }

    if (_value is not null) {
      return new(_keyTag, _value is GqlpUnit ? new GqlpUnit(_valueTag) : _value);
    }

    if (_list is not null) {
      return new(_keyTag, new GqlpList(_list.Items, _listTag, _list.Flow));
    }

    return new(_keyTag, new GqlpMap(_fields, _mapTag));
  }

  private GqlpList ReadList(ref Utf8JsonReader reader)
  {
    List<IGqlpValue> items = [];
    while (reader.Read()) {
      if (reader.TokenType == JsonTokenType.EndArray) {
        break;
      }

      items.Add(new ReadJson().ReadStructured(ref reader).Result);
    }

    return new(items);
  }
}

internal record struct KeyTagResult(string KeyTag, IGqlpValue Result);
