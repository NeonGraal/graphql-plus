using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;

namespace GqlPlus.Verifier.ClassTests;

internal sealed class TestsCustomizations : CompositeCustomization
{
  public TestsCustomizations() : base(new IdentifierCustomization()) { }

  internal sealed class IdentifierCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
      => fixture.Customizations.Add(new IdentifierSpecimenBuilder());
  }
  internal sealed class IdentifierSpecimenBuilder : ISpecimenBuilder
  {
    public object Create(object request, ISpecimenContext context)
    {
      var paramInfo = request as ParameterInfo;

      if (paramInfo is not null
        && !paramInfo.GetCustomAttributes<RegularExpressionAttribute>().Any()
      ) {
        if (paramInfo.ParameterType == typeof(string)) {
          return paramInfo.Name == "contents"
            ? context.Resolve(new RegularExpressionRequest(".{9,999}"))
            : context.Resolve(new RegularExpressionRequest(IdentifierPattern));
        }

        if (paramInfo.ParameterType == typeof(decimal)) {
          return context.Resolve(new RangedNumberRequest(paramInfo.ParameterType, -99999.99999, 99999.99999));
        }
      }

      var propInfo = request as PropertyInfo;

      if (propInfo is not null && propInfo.PropertyType == typeof(string)) {
        return context.Resolve(new RegularExpressionRequest(IdentifierPattern));
      }

      return new NoSpecimen();
    }
  }
}
