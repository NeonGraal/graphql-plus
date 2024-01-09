using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace GqlPlus.Verifier.Model;

internal class ModelTypeConverter : IYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new ModelTypeConverter();

  public bool Accepts(Type type) => type == typeof(ModelValue);
  public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();

  public void WriteYaml(IEmitter emitter, object? value, Type type)
  {
    if (value is ModelValue model) {
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

      var text = model switch { { Boolean: not null } => $"{model.Boolean}", { Decimal: not null } => $"{model.Decimal}", { String: not null } => model.String, { Identifier: not null } => model.Identifier,
        _ => ""
      };

      emitter.Emit(new Scalar(default, tag, text, ScalarStyle.Any, plainImplicit, isString));
    }
  }
}
