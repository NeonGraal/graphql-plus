using System.Reflection;

using AutoFixture;
using AutoFixture.Kernel;

namespace GqlPlus.AutoFixture;

public sealed class TestsCustomizations
  : CompositeCustomization
{
  public TestsCustomizations()
    : base(new TestCustomization())
  { }

  internal sealed class TestCustomization
    : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customizations.Insert(0, new StringArraySpecimenBuilder());
      fixture.Customizations.Insert(0, new RandomEnumSequenceGenerator());
      fixture.Customizations.Insert(0, new IdentifierSpecimenBuilder());
      fixture.Customizations.Insert(0, new DecimalSpecimenBuilder());
      fixture.Customizations.Insert(0, new BooleanSpecimenBuilder());
    }
  }
}
