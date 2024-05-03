using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;

namespace GqlPlus;

public sealed class TestsCustomizations : CompositeCustomization
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
        return ResolveType(paramInfo.ParameterType, paramInfo.Name!, context);
      }

      var propInfo = request as PropertyInfo;

      return propInfo is not null
        ? ResolveType(propInfo.PropertyType, propInfo.Name, context)
        : new NoSpecimen();
    }

    private static object ResolveType(Type type, string name, ISpecimenContext context)
    {
      if (type == typeof(string[])) {
        var resolution = context.Resolve(new RangedSequenceRequest(new RegularExpressionRequest(IdentifierPattern), 1, 5));
        return resolution is IEnumerable<object> list
          ? list.Select(item => item.ToString()).Distinct().ToArray()
          : resolution;
      }

      return type == typeof(string)
        ? name == "contents"
          ? context.Resolve(new RegularExpressionRequest(".{9,999}"))
          : context.Resolve(new RegularExpressionRequest(IdentifierPattern))
        : type == typeof(decimal) ? context.Resolve(new RangedNumberRequest(type, -99999.99999, 99999.99999)) : new NoSpecimen();
    }
  }
}
