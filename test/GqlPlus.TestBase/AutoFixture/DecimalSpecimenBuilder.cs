using AutoFixture.Kernel;

namespace GqlPlus.AutoFixture;

internal sealed class DecimalSpecimenBuilder
  : TypedSpecimenBuilder<decimal>
{
  protected override object TypedSpecimen(Type type, ISpecimenContext context)
    => context.Resolve(new RangedNumberRequest(type, -99999.99999, 99999.99999));
}
