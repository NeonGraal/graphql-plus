using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Verifier.Rendering;

internal static class RenderYaml
{
  internal static ISerializer Serializer { get; } = new SerializerBuilder()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .WithTypeConverter(RenderTypeConverter.Instance)
      .EnsureRoundtrip()
      .Build();

  internal static RenderStructure Render(this IEnumerable<string> strings, bool flow = true)
    => new("", strings.Select(a => new RenderStructure("", new RenderValue(a))), flow);

  internal static IEnumerable<RenderStructure> Render<T>(this IEnumerable<T> values)
    where T : IRendering
    => values.Select(v => v.Render());

  internal static string TrueFalse(this bool value)
    => value ? "true" : "false";
  internal static string TypeTag(this Type type)
    => "_" + type.Name.Replace("Model", "");
  internal static RenderStructure RenderEnum<TEnum>(this TEnum value)
    where TEnum : struct
    => new(value.GetType().TypeTag(), value.ToString());
}
