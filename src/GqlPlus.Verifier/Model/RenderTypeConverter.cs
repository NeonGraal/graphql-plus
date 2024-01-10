using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace GqlPlus.Verifier.Model;

internal class RenderTypeConverter : IYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new RenderTypeConverter();

  public bool Accepts(Type type) => type == typeof(RenderValue);
  public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();

  public void WriteYaml(IEmitter emitter, object? value, Type type)
  {
    if (value is RenderValue model) {
      var isString = !string.IsNullOrWhiteSpace(model.String);
      var plainImplicit = string.IsNullOrWhiteSpace(model.Tag) && !isString;
      var tag = isString || plainImplicit ? new TagName() : new TagName("!!" + model.Tag);
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
        emitter.Emit(new MappingStart(default, tag, plainImplicit, MappingStyle.Any));
        foreach (var kv in model.Map.OrderBy(kv => kv.Key)) {
          emitter.Emit(new Scalar(kv.Key));
          WriteYaml(emitter, kv.Value, type);
        }

        emitter.Emit(new MappingEnd());
        return;
      }

      var text = "";
      if (model.Identifier is not null) {
        text = model.Identifier;
      } else if (model.Boolean is not null) {
        text = model.Boolean?.TrueFalse()!;
      } else if (model.Decimal is not null) {
        text = $"{model.Decimal}";
      } else if (model.String is not null) {
        text = model.String;
      }

      emitter.Emit(new Scalar(default, tag, text, ScalarStyle.Any, plainImplicit, isString));
    }
  }
}
