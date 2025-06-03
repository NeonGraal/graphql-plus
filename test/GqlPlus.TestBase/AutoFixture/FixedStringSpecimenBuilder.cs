using System.Reflection;
using AutoFixture.Kernel;

namespace GqlPlus.AutoFixture;

internal sealed class FixedStringSpecimenBuilder : ISpecimenBuilder
{
  public object Create(object request, ISpecimenContext context)
    => request is ParameterInfo paramInfo
        && !paramInfo.GetCustomAttributes<RegularExpressionAttribute>().Any()
        && paramInfo.ParameterType == typeof(string)
      ? "AbcdeFghij"
      : new NoSpecimen();
}
