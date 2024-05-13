using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace GqlPlus.Rendering;

internal class RenderYamlTypeConverter
  : IYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new RenderYamlTypeConverter();

  public bool Accepts(Type type) => type == typeof(RenderStructure);

  public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();

  public void WriteYaml(IEmitter emitter, object? yaml, Type type)
  {
    if (yaml is RenderStructure model) {
      bool plainImplicit = string.IsNullOrWhiteSpace(model.Tag);
      TagName tag = plainImplicit ? new TagName() : new TagName("!" + model.Tag);
      if (model.List.Count > 0) {
        WriteList(emitter, type, model, plainImplicit);
      } else if (model.Map.Count > 0) {
        WriteMap(emitter, model, plainImplicit, tag);
      } else if (model.Value is not null) {
        WriteValue(emitter, model.Value, model.Tag);
      } else {
        emitter.Emit(new Scalar(default, model.Tag, string.Empty, ScalarStyle.Any, string.IsNullOrWhiteSpace(model.Tag), false));
      }
    }
  }

  private void WriteMap(IEmitter emitter, RenderStructure model, bool plainImplicit, TagName tag)
  {
    MappingStyle flow = model.Flow ? MappingStyle.Flow : MappingStyle.Any;
    emitter.Emit(new MappingStart(default, tag, plainImplicit, flow));
    foreach (KeyValuePair<RenderValue, RenderStructure> kv in model.Map.OrderBy(kv => kv.Key)) {
      WriteValue(emitter, kv.Key, kv.Key.Tag);
      WriteYaml(emitter, kv.Value, kv.Value.GetType());
    }

    emitter.Emit(new MappingEnd());
  }

  private void WriteList(IEmitter emitter, Type type, RenderStructure model, bool plainImplicit)
  {
    SequenceStyle flow = model.Flow ? SequenceStyle.Flow : SequenceStyle.Any;
    emitter.Emit(new SequenceStart(default, default, plainImplicit, flow));
    foreach (RenderStructure item in model.List) {
      WriteYaml(emitter, item, type);
    }

    emitter.Emit(new SequenceEnd());
  }

  private static void WriteValue(IEmitter emitter, RenderValue value, string tag)
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
      style = text.Contains('\'', StringComparison.Ordinal)
        ? ScalarStyle.DoubleQuoted : ScalarStyle.SingleQuoted;

      if (text.Length > RenderYaml.BestWidth / 2) {
        style = ScalarStyle.Folded;
      }
    }

    emitter.Emit(new Scalar(default, tagName, text!, style, plainImplicit, isString));
  }
}
