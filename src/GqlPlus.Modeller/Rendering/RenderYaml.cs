using System.Reflection.Emit;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Rendering;

public static class RenderYaml
{
  internal static int BestWidth = 60;
  internal static ISerializer YamlSerializer { get; }

  static RenderYaml()
  {
    IValueSerializer valueSerializer = new SerializerBuilder()
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .EnsureRoundtrip()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .WithTypeConverter(RenderYamlTypeConverter.Instance)
      .BuildValueSerializer();

    EmitterSettings settings = EmitterSettings.Default.WithBestWidth(BestWidth);

    YamlSerializer = Serializer.FromValueSerializer(valueSerializer, settings);
  }

  public static string ToYaml(this RenderStructure model)
    => YamlSerializer.Serialize(model);

  public static string[] YamlWidth(this IEnumerable<string> list, string start, string end)
  {
    List<string> result = [];
    string line = start;
    string sep = "";

    foreach (string item in list ?? []) {
      if (line.Length > BestWidth) {
        result.Add(line + ",");
        line = " ";
        sep = " ";
      }

      line += sep + item;
      sep = ", ";
    };

    result.Add(line + end);

    return [.. result];

  }
}
