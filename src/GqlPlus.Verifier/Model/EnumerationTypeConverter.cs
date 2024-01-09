using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace GqlPlus.Verifier.Model;

public class EnumerationTypeConverter : IYamlTypeConverter
{
  public static readonly IYamlTypeConverter Instance = new EnumerationTypeConverter();

  public bool Accepts(Type type) => type.IsEnum;
  public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();
  public void WriteYaml(IEmitter emitter, object? value, Type type)
  {
    var tag = new TagName("!!_" + type.Name.Replace("Model", ""));
    var scalar = new Scalar(new AnchorName(), tag, $"{value}", ScalarStyle.Any, false, false);
    emitter.Emit(scalar);
  }
}
