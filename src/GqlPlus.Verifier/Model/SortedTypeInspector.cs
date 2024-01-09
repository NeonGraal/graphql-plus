using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

namespace GqlPlus.Verifier.Model;

public class SortedTypeInspector : TypeInspectorSkeleton
{
  private readonly ITypeInspector _innerTypeInspector;

  public SortedTypeInspector(ITypeInspector innerTypeInspector)
    => _innerTypeInspector = innerTypeInspector;

  public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object? container)
    => _innerTypeInspector.GetProperties(type, container).OrderBy(x => x.Name);
}
