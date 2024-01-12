using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace GqlPlus.Verifier.Rendering;

internal class RenderTypeConverter : IYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new RenderTypeConverter();

  public bool Accepts(Type type) => type == typeof(RenderStructure) || type == typeof(RenderValue);
  public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();

  public void WriteYaml(IEmitter emitter, object? yaml, Type type)
  {
    if (yaml is RenderValue value) {
      WriteValue(emitter, value, "");
      return;
    }

    if (yaml is RenderStructure model) {
      var plainImplicit = string.IsNullOrWhiteSpace(model.Tag);
      var tag = plainImplicit ? new TagName() : new TagName("!" + model.Tag);
      if (model.List.Count > 0) {
        var flow = model.Flow ? SequenceStyle.Flow : SequenceStyle.Any;
        emitter.Emit(new SequenceStart(default, default, plainImplicit, flow));
        foreach (var item in model.List) {
          WriteYaml(emitter, item, type);
        }

        emitter.Emit(new SequenceEnd());
        return;
      }

      if (model.Map.Count > 0) {
        var flow = model.Flow ? MappingStyle.Flow : MappingStyle.Any;
        emitter.Emit(new MappingStart(default, tag, plainImplicit, flow));
        foreach (var kv in model.Map.OrderBy(kv => kv.Key)) {
          WriteValue(emitter, kv.Key, "");
          WriteYaml(emitter, kv.Value, kv.Value.GetType());
        }

        emitter.Emit(new MappingEnd());
        return;
      }

      if (model.Value is not null) {
        WriteValue(emitter, model.Value, model.Tag);
      }
    }
  }

  private void WriteValue(IEmitter emitter, RenderValue value, string tag)
  {
    var isString = !string.IsNullOrWhiteSpace(value.String);
    var plainImplicit = string.IsNullOrWhiteSpace(tag) && !isString;
    var tagName = isString || plainImplicit ? new TagName() : new TagName("!" + tag);

    var text = string.Empty;
    if (value.Identifier is not null) {
      text = value.Identifier;
    } else if (value.Boolean is not null) {
      text = value.Boolean?.TrueFalse();
    } else if (value.Decimal is not null) {
      text = $"{value.Decimal}";
    } else if (value.String is not null) {
      text = value.String;
    }

    emitter.Emit(new Scalar(default, tagName, text!, ScalarStyle.Any, plainImplicit, isString));
  }
}
