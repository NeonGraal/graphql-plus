using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Rendering;

public static class RenderYaml
{
  internal static int BestWidth = 60;
  internal static ISerializer YamlFull { get; }
  internal static ISerializer YamlWrapped { get; }

  static RenderYaml()
  {
    IValueSerializer valueSerializer = new SerializerBuilder()
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .EnsureRoundtrip()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .WithTypeConverter(RenderYamlTypeConverter.Instance)
      .BuildValueSerializer();

    EmitterSettings settings = EmitterSettings.Default.WithBestWidth(BestWidth);

    YamlFull = Serializer.FromValueSerializer(valueSerializer, EmitterSettings.Default);
    YamlWrapped = Serializer.FromValueSerializer(valueSerializer, settings);
  }

  public static string ToYaml(this RenderStructure model, bool wrapped)
    => (wrapped ? YamlWrapped : YamlFull).Serialize(model);

  public static string YamlJoin(this IEnumerable<string> list, string start, string end)
    => start + string.Join(", ", list ?? []) + end;
}
