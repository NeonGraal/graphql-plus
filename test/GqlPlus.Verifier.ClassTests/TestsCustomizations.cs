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
      var pi = request as ParameterInfo;

      if (pi is not null
        && !pi.GetCustomAttributes<RegularExpressionAttribute>().Any()
      ) {
        if (pi.ParameterType == typeof(string)) {
          return pi.Name == "contents"
            ? context.Resolve(new RegularExpressionRequest(".{9,999}"))
            : context.Resolve(new RegularExpressionRequest(IdentifierPattern));
        }

        if (pi.ParameterType == typeof(decimal)) {
          return context.Resolve(new RangedNumberRequest(pi.ParameterType, -99999.99999, 99999.99999));
        }
      }

      return new NoSpecimen();
    }
  }
}
