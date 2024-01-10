using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Verifier.Model;

public static class RenderYaml
{
  public static ISerializer Serializer { get; } = new SerializerBuilder()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .WithTypeInspector(x => new SortedTypeInspector(x))
      .WithTypeConverter(EnumerationTypeConverter.Instance)
      .WithTypeConverter(ModelTypeConverter.Instance)
      .EnsureRoundtrip()
      .Build();

  public static RenderValue Render(this IEnumerable<string> strings, bool flow = true)
    => new("", strings.Select(a => new RenderValue("", a)), flow);
}
