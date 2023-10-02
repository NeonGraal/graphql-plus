using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;
using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

internal class TestsCustomizations : CompositeCustomization
{
  public TestsCustomizations() : base(new IdentifierCustomization()) { }

  internal class IdentifierCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
      => fixture.Customizations.Add(new IdentifierSpecimenBuilder());
  }
  internal class IdentifierSpecimenBuilder : ISpecimenBuilder
  {
    public object Create(object request, ISpecimenContext context)
    {
      var pi = request as ParameterInfo;

      if (pi is not null && !pi.GetCustomAttributes<RegularExpressionAttribute>().Any()) {
        if (pi.ParameterType == typeof(string)) {
          if (pi.Name == "contents") {
            var contents = (string)context.Resolve(new ConstrainedStringRequest(999));
            if (contents.Contains('"')) {
              if (contents.Contains("'")) {
                return "'" + contents.Replace("'", "\\'") + "'";
              } else {
                return $"'{contents}'";
              }
            }
            return '"' + contents + '"';
          }
          return context.Resolve(new RegularExpressionRequest(IdentifierPattern));
        }
        if (pi.ParameterType == typeof(decimal)) {
          return context.Resolve(new RangedNumberRequest(pi.ParameterType, -99999.99999, 99999.99999));
        }
      }

      return new NoSpecimen();
    }
  }
}
