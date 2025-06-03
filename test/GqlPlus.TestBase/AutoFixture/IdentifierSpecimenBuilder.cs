using System.Reflection;
using AutoFixture.Kernel;

namespace GqlPlus.AutoFixture;

internal sealed class IdentifierSpecimenBuilder : ISpecimenBuilder
{
  public object Create(object request, ISpecimenContext context)
    => request switch {
      ParameterInfo paramInfo
        => paramInfo.GetCustomAttributes<RegularExpressionAttribute>().Any()
          ? new NoSpecimen()
          : ResolveType(paramInfo.ParameterType, paramInfo.Name!, context),
      PropertyInfo propInfo
        => ResolveType(propInfo.PropertyType, propInfo.Name, context),
      _ => new NoSpecimen()
    };

  private static object ResolveType(Type type, string name, ISpecimenContext context)
    => type == typeof(string)
      ? name == "contents"
        ? context.Resolve(new RegularExpressionRequest(".{9,999}"))
        : context.Resolve(new RegularExpressionRequest(IdentifierPattern))
      : new NoSpecimen();
}
