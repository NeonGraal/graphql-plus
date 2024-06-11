using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Convert;

public static class RenderYaml
{
  internal static int BestWidth = 60;
  internal static ISerializer YamlFull { get; }
  internal static ISerializer YamlWrapped { get; }

  static RenderYaml()
  {
    SerializerBuilder builder = new SerializerBuilder()
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .EnsureRoundtrip()
      .WithNamingConvention(CamelCaseNamingConvention.Instance);

    YamlFull = builder
      .WithTypeConverter(RenderYamlFullConverter.Instance)
      .Build();

    EmitterSettings settings = EmitterSettings
      .Default
      .WithBestWidth(BestWidth);

    YamlWrapped = Serializer.FromValueSerializer(
      builder
        .WithTypeConverter(RenderYamlWrappedConverter.Instance)
        .BuildValueSerializer(),
      settings);
  }

  public static string ToYaml(this RenderStructure model, bool wrapped)
    => (wrapped ? YamlWrapped : YamlFull).Serialize(model);

  public static string YamlJoin(this IEnumerable<string> list, string start, string end)
    => start + string.Join(", ", list ?? []) + end;
}
