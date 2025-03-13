using AutoFixture.Kernel;

namespace GqlPlus.AutoFixture;

internal class RandomEnumSequenceGenerator : ISpecimenBuilder
{
  private static readonly Random s_random = new();

  public object Create(object request, ISpecimenContext context)
  {
    if (!(request is Type type && type.IsEnum)) {
      return new NoSpecimen();
    }

    Array values = Enum.GetValues(type);
#pragma warning disable CA5394 // Do not use insecure randomness
    int index = s_random.Next(values.Length);
#pragma warning restore CA5394 // Do not use insecure randomness
    return values.GetValue(index)!;
  }
}
