using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Verifier.Model;

public class ModelYaml
{
  public static ISerializer Serializer = new SerializerBuilder()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .WithTypeInspector(x => new SortedTypeInspector(x))
      .WithTypeConverter(EnumerationTypeConverter.Instance)
      .WithTypeConverter(ModelTypeConverter.Instance)
      .EnsureRoundtrip()
      .Build();
}
