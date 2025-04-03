using AutoFixture.Kernel;

namespace GqlPlus.AutoFixture;

internal abstract class TypedSpecimenBuilder<T> : ISpecimenBuilder
{
  public object Create(object request, ISpecimenContext context)
    => request is Type type && type == typeof(T) ? TypedSpecimen(type, context) : new NoSpecimen();

  protected abstract object TypedSpecimen(Type type, ISpecimenContext context);
}
