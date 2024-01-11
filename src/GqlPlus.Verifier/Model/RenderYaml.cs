using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Verifier.Model;

public static class RenderYaml
{
  public static ISerializer Serializer { get; } = new SerializerBuilder()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .WithTypeConverter(RenderTypeConverter.Instance)
      .EnsureRoundtrip()
      .Build();

  public static RenderValue Render(this IEnumerable<string> strings, bool flow = true)
    => new("", strings.Select(a => new RenderValue("", a)), flow);

  public static IEnumerable<RenderValue> Render<T>(this IEnumerable<T> values)
    where T : IRendering
    => values.Select(v => v.Render());

  public static string TrueFalse(this bool value)
    => value ? "true" : "false";
}
