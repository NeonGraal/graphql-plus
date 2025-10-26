﻿using AutoFixture;

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

  public static Func<IFixture> CreateFixture(bool localTests = false)
    => () => {
      Fixture fixture = new();
      fixture.Customize(new TestsCustomizations());
      if (localTests) {
        fixture.Customizations.Insert(0, new FixedStringSpecimenBuilder());
      }

      return fixture;
    };

  private static readonly Lazy<bool> s_isCi = new(() =>
    bool.TryParse(Environment.GetEnvironmentVariable("CI"), out bool isCi) && isCi);

  public static bool IsCi => s_isCi.Value;
}
