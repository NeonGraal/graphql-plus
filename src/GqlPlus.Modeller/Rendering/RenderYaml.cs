using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Rendering;

internal static class RenderYaml
{
  internal static ISerializer Serializer { get; } = new SerializerBuilder()
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .EnsureRoundtrip()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .WithTypeConverter(RenderYamlTypeConverter.Instance)
      .Build();
}
