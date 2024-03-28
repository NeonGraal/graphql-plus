using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace GqlPlus.Verifier.Rendering;

internal class RenderTypeConverter : IYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new RenderTypeConverter();

  public bool Accepts(Type type) => type == typeof(RenderStructure);

  [ExcludeFromCodeCoverage]
  public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();

  public void WriteYaml(IEmitter emitter, object? yaml, Type type)
  {
    if (yaml is RenderStructure model) {
      var plainImplicit = string.IsNullOrWhiteSpace(model.Tag);
      var tag = plainImplicit ? new TagName() : new TagName("!" + model.Tag);
      if (model.List.Count > 0) {
        WriteList(emitter, type, model, plainImplicit);
      } else if (model.Map.Count > 0) {
        var (_, first) = model.Map.First();
        if (model.Map.Count == 1 && !plainImplicit && string.IsNullOrWhiteSpace(first.Tag) && first.Value is not null) {
          WriteValue(emitter, first.Value, model.Tag);
        } else {
          WriteMap(emitter, model, plainImplicit, tag);
        }
      } else if (model.Value is not null) {
        WriteValue(emitter, model.Value, model.Tag);
      }
    }
  }

  private void WriteMap(IEmitter emitter, RenderStructure model, bool plainImplicit, TagName tag)
  {
    var flow = model.Flow ? MappingStyle.Flow : MappingStyle.Any;
    emitter.Emit(new MappingStart(default, tag, plainImplicit, flow));
    foreach (var kv in model.Map.OrderBy(kv => kv.Key)) {
      WriteValue(emitter, kv.Key, "");
      WriteYaml(emitter, kv.Value, kv.Value.GetType());
    }

    emitter.Emit(new MappingEnd());
  }

  private void WriteList(IEmitter emitter, Type type, RenderStructure model, bool plainImplicit)
  {
    var flow = model.Flow ? SequenceStyle.Flow : SequenceStyle.Any;
    emitter.Emit(new SequenceStart(default, default, plainImplicit, flow));
    foreach (var item in model.List) {
      WriteYaml(emitter, item, type);
    }

    emitter.Emit(new SequenceEnd());
  }

  private static void WriteValue(IEmitter emitter, RenderValue value, string tag)
  {
    var isString = !string.IsNullOrWhiteSpace(value.Text);
    var plainImplicit = string.IsNullOrWhiteSpace(tag) && !isString;
    var tagName = isString || plainImplicit ? new TagName() : new TagName("!" + tag);

    var text = string.Empty;
    if (value.Identifier is not null) {
      text = value.Identifier;
    } else if (value.Boolean is not null) {
      text = value.Boolean.Value.TrueFalse();
    } else if (value.Number is not null) {
      text = $"{value.Number}";
    } else if (value.Text is not null) {
      text = value.Text;
    }

    emitter.Emit(new Scalar(default, tagName, text!, isString ? ScalarStyle.SingleQuoted : ScalarStyle.Any, plainImplicit, isString));
  }
}
