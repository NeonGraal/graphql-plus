using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace GqlPlus.Convert;

internal class RenderYamlFullConverter
  : RenderYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new RenderYamlFullConverter();
}

internal class RenderYamlWrappedConverter
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
  public bool Accepts(Type type) => type == typeof(RenderStructure);

  public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();
  public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException();
  public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer)
  {
    if (value is RenderStructure model) {
      bool plainImplicit = string.IsNullOrWhiteSpace(model.Tag);
      TagName tag = plainImplicit ? new TagName() : new TagName("!" + model.Tag);
      if (model.List.Count > 0) {
        WriteList(emitter, type, model, plainImplicit, serializer);
      } else if (model.Map.Count > 0) {
        WriteMap(emitter, model, plainImplicit, tag, serializer);
      } else if (model.Value is not null) {
        WriteValue(emitter, model.Value, model.Tag);
      } else {
        emitter.Emit(new Scalar(default, model.Tag, string.Empty, ScalarStyle.Any, string.IsNullOrWhiteSpace(model.Tag), false));
      }
    }
  }

  private void WriteMap(IEmitter emitter, RenderStructure model, bool plainImplicit, TagName tag, ObjectSerializer serializer)
  {
    MappingStyle flow = model.Flow ? MappingStyle.Flow : MappingStyle.Any;
    emitter.Emit(new MappingStart(default, tag, plainImplicit, flow));
    foreach (KeyValuePair<RenderValue, RenderStructure> kv in model.Map.OrderBy(kv => kv.Key)) {
      WriteValue(emitter, kv.Key, kv.Key.Tag);
      WriteYaml(emitter, kv.Value, kv.Value.GetType(), serializer);
    }

    emitter.Emit(new MappingEnd());
  }

  private void WriteList(IEmitter emitter, Type type, RenderStructure model, bool plainImplicit, ObjectSerializer serializer)
  {
    SequenceStyle flow = model.Flow ? SequenceStyle.Flow : SequenceStyle.Any;
    emitter.Emit(new SequenceStart(default, default, plainImplicit, flow));
    foreach (RenderStructure item in model.List) {
      WriteYaml(emitter, item, type, serializer);
    }

    emitter.Emit(new SequenceEnd());
  }

  private void WriteValue(IEmitter emitter, RenderValue value, string tag)
  {
    bool isString = !string.IsNullOrWhiteSpace(value.Text);
    bool plainImplicit = string.IsNullOrWhiteSpace(tag) && !isString;
    TagName tagName = isString || plainImplicit ? new TagName() : new TagName("!" + tag);

    string text = string.Empty;
    if (value.Identifier is not null) {
      text = value.Identifier;
    } else if (value.Boolean is not null) {
      text = value.Boolean.Value.TrueFalse();
    } else if (value.Number is not null) {
      text = $"{value.Number}";
    } else if (value.Text is not null) {
      text = value.Text;
    }

    ScalarStyle style = ScalarStyle.Any;
    if (isString) {
      style = GetStringScalarStyle(text);
    }

    emitter.Emit(new Scalar(default, tagName, text!, style, plainImplicit, isString));
  }

  protected virtual ScalarStyle GetStringScalarStyle(string text)
    => text.Contains('\'', StringComparison.Ordinal)
      ? ScalarStyle.DoubleQuoted
      : ScalarStyle.SingleQuoted;
}
