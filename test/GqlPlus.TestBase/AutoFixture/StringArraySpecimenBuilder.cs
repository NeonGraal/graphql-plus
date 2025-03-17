using AutoFixture.Kernel;

namespace GqlPlus.AutoFixture;

internal sealed class StringArraySpecimenBuilder
  : TypedSpecimenBuilder<string[]>
{
  protected override object TypedSpecimen(Type type, ISpecimenContext context)
  {
    RegularExpressionRequest identifier = new(IdentifierPattern);
    RangedSequenceRequest sequence = new(identifier, 1, 5);
    object resolution = context.Resolve(sequence);
    return resolution is IEnumerable<object> list
      ? list.Select(item => item.ToString()).Distinct().ToArray()
      : resolution;
  }
}
