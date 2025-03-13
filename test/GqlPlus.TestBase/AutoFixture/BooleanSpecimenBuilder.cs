using AutoFixture.Kernel;

namespace GqlPlus.AutoFixture;

internal sealed class BooleanSpecimenBuilder : TypedSpecimenBuilder<bool>
{
  private static bool s_boolValue;

  protected override object TypedSpecimen(Type type, ISpecimenContext context)
    => s_boolValue = !s_boolValue;
}
