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
  public bool Accepts(Type type) => typeof(IGqlpValue).IsAssignableFrom(type);

  public object? ReadYaml(IParser parser, Type type)
  {
    if (type == null) {
      throw new ArgumentNullException(nameof(type));
    }

    return parser.Current switch {
      Scalar => ReadScalar(parser),
      SequenceStart => ReadList(parser),
      MappingStart => ReadMap(parser),
      _ => throw new InvalidOperationException($"Unexpected token type: {parser.Current}")
    };
  }

  public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
    => ReadYaml(parser, type);

  public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer)
  {
    if (value is not IGqlpValue model) {
      return;
    }

    bool plainImplicit = string.IsNullOrWhiteSpace(model.Tag);
    TagName tag = plainImplicit ? new TagName() : new TagName("!" + model.Tag);
    switch (model) {
      case GqlpList list:
        WriteList(emitter, list, plainImplicit, tag, serializer);
        break;
      case GqlpMap map:
        WriteMap(emitter, map, plainImplicit, tag, serializer);
        break;
      case IGqlpScalar scalar when !ScalarIsEmpty(scalar):
        WriteValue(emitter, scalar, scalar.Tag);
        break;
      default:
        emitter.Emit(new Scalar(default, tag, string.Empty, ScalarStyle.Any, plainImplicit, false));
        break;
    }
  }

  private GqlpMap ReadMap(IParser parser)
  {
    MappingStart start = parser.Consume<MappingStart>().ThrowIfNull();
    string? tag = start.Tag.IsEmpty ? null : start.Tag.Value.TrimStart('!');
    List<KeyValuePair<IGqlpScalar, IGqlpValue>> items = [];
    while (parser.Current is not MappingEnd) {
      IGqlpValue key = ReadValue(parser);
      if (key is IGqlpScalar scalar && ReadYaml(parser, typeof(IGqlpValue)) is IGqlpValue structured) {
        items.Add(new(scalar, structured));
      }
    }

    parser.Consume<MappingEnd>().ThrowIfNull();
    return new(items, tag, flow: start.Style == MappingStyle.Flow);
  }

  private void WriteMap(IEmitter emitter, GqlpMap model, bool plainImplicit, TagName tag, ObjectSerializer serializer)
  {
    MappingStyle flow = model.Flow ? MappingStyle.Flow : MappingStyle.Any;
    emitter.Emit(new MappingStart(default, tag, plainImplicit, flow));
    foreach (KeyValuePair<IGqlpScalar, IGqlpValue> kv in model.Entries.OrderBy(kv => kv.Key.Tag, StringComparer.Ordinal)
      .ThenBy(kv => (int)kv.Key.Kind)
      .ThenBy(kv => kv.Key.Kind == GqlpScalarKind.Number ? kv.Key.Number : 0)
      .ThenBy(kv => kv.Key.Kind == GqlpScalarKind.Boolean ? kv.Key.BooleanValue : null)
      .ThenBy(kv => kv.Key.Text, StringComparer.Ordinal)) {
      WriteValue(emitter, kv.Key, kv.Key.Tag);
      WriteYaml(emitter, kv.Value, typeof(IGqlpValue), serializer);
    }

    emitter.Emit(new MappingEnd());
  }

  private GqlpList ReadList(IParser parser)
  {
    SequenceStart start = parser.Consume<SequenceStart>().ThrowIfNull();
    string? tag = start.Tag.IsEmpty ? null : start.Tag.Value.TrimStart('!');
    List<IGqlpValue> items = [];
    while (parser.Current is not SequenceEnd) {
      if (ReadYaml(parser, typeof(IGqlpValue)) is IGqlpValue structured) {
        items.Add(structured);
      }
    }

    parser.Consume<SequenceEnd>().ThrowIfNull();
    return new(items, tag, flow: start.Style == SequenceStyle.Flow);
  }

  private void WriteList(IEmitter emitter, GqlpList model, bool plainImplicit, TagName tag, ObjectSerializer serializer)
  {
    SequenceStyle flow = model.Flow ? SequenceStyle.Flow : SequenceStyle.Any;
    emitter.Emit(new SequenceStart(default, tag, plainImplicit, flow));
    foreach (IGqlpValue item in model.Items) {
      WriteYaml(emitter, item, typeof(IGqlpValue), serializer);
    }

    emitter.Emit(new SequenceEnd());
  }

  private GqlpScalar ReadValue(IParser parser)
  {
    Scalar current = parser.Consume<Scalar>().ThrowIfNull();
    string? tag = current.Tag.IsEmpty ? null : current.Tag.Value.TrimStart('!');
    if (decimal.TryParse(current.Value, out decimal number)) {
      return new GqlpScalar(number, tag);
    }

    if (bool.TryParse(current.Value, out bool boolean)) {
      return new GqlpScalar(boolean, tag);
    }

    return new GqlpScalar(current.Value, tag, isIdentifier: current.Value.IsIdentifier());
  }

  private IGqlpValue ReadScalar(IParser parser)
  {
    GqlpScalar value = ReadValue(parser);
    return ScalarIsEmpty(value)
      ? string.IsNullOrWhiteSpace(value.Tag) ? new GqlpUnit() : new GqlpUnit(value.Tag)
      : value;
  }

  private void WriteValue(IEmitter emitter, IGqlpScalar value, string tag)
  {
    bool isString = value.Kind == GqlpScalarKind.Text && !string.IsNullOrEmpty(value.Text);
    bool plainImplicit = string.IsNullOrWhiteSpace(tag);
    TagName tagName = plainImplicit ? new TagName() : new TagName("!" + tag);
    string text = value.Kind switch {
      GqlpScalarKind.Boolean => value.BooleanValue!.Value.TrueFalse(),
      GqlpScalarKind.Number => $"{value.Number}",
      _ => value.Text ?? "",
    };

    ScalarStyle style = isString ? GetStringScalarStyle(text) : ScalarStyle.Any;
    emitter.Emit(new Scalar(default, tagName, text, style, plainImplicit, false));
  }

  private static bool ScalarIsEmpty(IGqlpScalar value)
    => (value.Kind is GqlpScalarKind.Text or GqlpScalarKind.Identifier) && string.IsNullOrEmpty(value.Text);

  protected virtual ScalarStyle GetStringScalarStyle(string text)
    => text.Contains('\'')
      ? ScalarStyle.DoubleQuoted
      : ScalarStyle.SingleQuoted;
}
