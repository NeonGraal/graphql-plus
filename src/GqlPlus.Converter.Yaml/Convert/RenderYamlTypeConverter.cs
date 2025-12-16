using YamlDotNet.Core.Events;

namespace GqlPlus.Convert;

internal sealed class RenderYamlFullConverter
  : RenderYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new RenderYamlFullConverter();
}

internal sealed class RenderYamlWrappedConverter
  : RenderYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new RenderYamlWrappedConverter();

  protected override ScalarStyle GetStringScalarStyle(string text)
    => text.Length > RenderYaml.BestWidth / 2
      ? ScalarStyle.Folded
      : base.GetStringScalarStyle(text);
}

internal class RenderYamlTypeConverter
  : IYamlTypeConverter
{
  public bool Accepts(Type type) => type == typeof(Structured);

  public object? ReadYaml(IParser parser, Type type)
  {
    if (type == null) throw new ArgumentNullException(nameof(type));

    // Deserialize the YAML data to the specified type
    return parser.Current switch {
      // Handle different token types accordingly
      Scalar => ReadValue(parser),
      SequenceStart => ReadList(parser, type),
      MappingStart => ReadMap(parser, type),
      _ => throw new InvalidOperationException($"Unexpected token type: {parser.Current}")
    };
  }

  public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
    => ReadYaml(parser, type);

  public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer)
  {
    if (value is Structured model) {
      bool plainImplicit = string.IsNullOrWhiteSpace(model.Tag);
      TagName tag = plainImplicit ? new TagName() : new TagName("!" + model.Tag);
      if (model.List.Count > 0) {
        WriteList(emitter, type, model, plainImplicit, tag, serializer);
      } else if (model.Map.Count > 0) {
        WriteMap(emitter, model, plainImplicit, tag, serializer);
      } else if (model.Value is not null) {
        WriteValue(emitter, model.Value, model.Tag);
      } else {

        if (string.IsNullOrWhiteSpace(model.Tag)) {
          emitter.Emit(new Scalar(""));
        } else {
          emitter.Emit(new Scalar(default, model.Tag, string.Empty, ScalarStyle.Any, false, false));
        }
      }
    }
  }

  private Structured ReadMap(IParser parser, Type type)
  {
    MappingStart start = parser.Consume<MappingStart>().ThrowIfNull();
    string? tag = start.Tag.IsEmpty ? null : start.Tag.Value.TrimStart('!');
    Dictionary<StructureValue, Structured> items = [];
    while (parser.Current is not MappingEnd) {
      Structured key = ReadValue(parser);
      if (key.Value is not null && ReadYaml(parser, type) is Structured structured) {
        items.Add(key.Value, structured);
      }
    }

    parser.Consume<MappingEnd>().ThrowIfNull();
    return new(items, tag, flow: start.Style == MappingStyle.Flow);
  }
  private void WriteMap(IEmitter emitter, Structured model, bool plainImplicit, TagName tag, ObjectSerializer serializer)
  {
    MappingStyle flow = model.Flow ? MappingStyle.Flow : MappingStyle.Any;
    emitter.Emit(new MappingStart(default, tag, plainImplicit, flow));
    foreach (KeyValuePair<StructureValue, Structured> kv in model.Map.OrderBy(kv => kv.Key)) {
      WriteValue(emitter, kv.Key, kv.Key.Tag);
      WriteYaml(emitter, kv.Value, kv.Value.GetType(), serializer);
    }

    emitter.Emit(new MappingEnd());
  }

  private Structured ReadList(IParser parser, Type type)
  {
    SequenceStart start = parser.Consume<SequenceStart>().ThrowIfNull();
    string? tag = start.Tag.IsEmpty ? null : start.Tag.Value.TrimStart('!');
    List<Structured> items = [];
    while (parser.Current is not SequenceEnd) {
      if (ReadYaml(parser, type) is Structured structured) {
        items.Add(structured);
      }
    }

    parser.Consume<SequenceEnd>().ThrowIfNull();
    return new(items, tag, flow: start.Style == SequenceStyle.Flow);
  }
  private void WriteList(IEmitter emitter, Type type, Structured model, bool plainImplicit, TagName tag, ObjectSerializer serializer)
  {
    SequenceStyle flow = model.Flow ? SequenceStyle.Flow : SequenceStyle.Any;
    emitter.Emit(new SequenceStart(default, tag, plainImplicit, flow));
    foreach (Structured item in model.List) {
      WriteYaml(emitter, item, type, serializer);
    }

    emitter.Emit(new SequenceEnd());
  }

  private Structured ReadValue(IParser parser)
  {
    Scalar current = parser.Consume<Scalar>().ThrowIfNull();
    string? tag = current.Tag.IsEmpty ? null : current.Tag.Value.TrimStart('!');
    if (decimal.TryParse(current.Value, out decimal number)) {
      return new(number, tag);
    }

    if (bool.TryParse(current.Value, out bool boolean)) {
      return new(boolean, tag);
    }

    return new(current.Value, tag);
  }
  private void WriteValue(IEmitter emitter, StructureValue value, string tag)
  {
    bool isString = !string.IsNullOrEmpty(value.Text) && string.IsNullOrWhiteSpace(value.Identifier);
    bool plainImplicit = string.IsNullOrWhiteSpace(tag);
    TagName tagName = plainImplicit ? new TagName() : new TagName("!" + tag);

    string text = "";
    if (!string.IsNullOrWhiteSpace(value.Identifier)) {
      text = value.Identifier!;
    } else if (value.Boolean is not null) {
      text = value.Boolean.Value.TrueFalse();
    } else if (value.Number is not null) {
      text = $"{value.Number}";
    } else if (!string.IsNullOrEmpty(value.Text)) {
      text = value.Text!;
    }

    ScalarStyle style = ScalarStyle.Any;
    if (isString) {
      style = GetStringScalarStyle(text);
    }

    emitter.Emit(new Scalar(default, tagName, text!, style, plainImplicit, false));
  }

  protected virtual ScalarStyle GetStringScalarStyle(string text)
    => text.Contains('\'')
      ? ScalarStyle.DoubleQuoted
      : ScalarStyle.SingleQuoted;
}
