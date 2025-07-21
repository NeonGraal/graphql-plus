using System.Diagnostics.CodeAnalysis;
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

  [ExcludeFromCodeCoverage]
  public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();
  [ExcludeFromCodeCoverage]
  public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException();

  public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer)
  {
    if (value is Structured model) {
      bool plainImplicit = string.IsNullOrWhiteSpace(model.Tag);
      TagName tag = plainImplicit ? new TagName() : new TagName("!" + model.Tag);
      if (model.List.Count > 0) {
        WriteList(emitter, type, model, plainImplicit, serializer);
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

  private void WriteList(IEmitter emitter, Type type, Structured model, bool plainImplicit, ObjectSerializer serializer)
  {
    SequenceStyle flow = model.Flow ? SequenceStyle.Flow : SequenceStyle.Any;
    emitter.Emit(new SequenceStart(default, default, plainImplicit, flow));
    foreach (Structured item in model.List) {
      WriteYaml(emitter, item, type, serializer);
    }

    emitter.Emit(new SequenceEnd());
  }

  private void WriteValue(IEmitter emitter, StructureValue value, string tag)
  {
    bool isString = !string.IsNullOrEmpty(value.Text) && string.IsNullOrWhiteSpace(value.Identifier);
    bool plainImplicit = tag.IsWhiteSpace() && !isString;
    TagName tagName = isString || plainImplicit ? new TagName() : new TagName("!" + tag);

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

    emitter.Emit(new Scalar(default, tagName, text!, style, plainImplicit, isString));
  }

  protected virtual ScalarStyle GetStringScalarStyle(string text)
    => text.Contains('\'')
      ? ScalarStyle.DoubleQuoted
      : ScalarStyle.SingleQuoted;
}
