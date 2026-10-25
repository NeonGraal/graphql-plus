using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.NodeTypeResolvers;

namespace GqlPlus.Convert;

public static class RenderYaml
{
  public const int BestWidth = 60;

  internal static ISerializer YamlFull { get; }
  internal static ISerializer YamlWrapped { get; }
  internal static IDeserializer YamlDeserializer { get; } = new DeserializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .WithTypeConverter(RenderYamlFullConverter.Instance)
    .IgnoreUnmatchedProperties()
    .WithoutNodeTypeResolver<PreventUnknownTagsNodeTypeResolver>()
    .Build();

  static RenderYaml()
  {
    SerializerBuilder serializer = new SerializerBuilder()
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .EnsureRoundtrip()
      .WithNamingConvention(CamelCaseNamingConvention.Instance);

    YamlFull = serializer
      .WithTypeConverter(RenderYamlFullConverter.Instance)
      .Build();

    EmitterSettings settings = EmitterSettings
      .Default
      .WithBestWidth(BestWidth);

    YamlWrapped = Serializer.FromValueSerializer(
      serializer
        .WithTypeConverter(RenderYamlWrappedConverter.Instance)
        .BuildValueSerializer(),
      settings);
  }

  public static string ToYaml(this IGqlpValue model, bool wrapped)
    => (wrapped ? YamlWrapped : YamlFull).Serialize(model);
  public static IGqlpValue FromYaml(this IEnumerable<string> yaml)
    => YamlDeserializer.Deserialize<IGqlpValue>(yaml.Joined(Environment.NewLine));
}
