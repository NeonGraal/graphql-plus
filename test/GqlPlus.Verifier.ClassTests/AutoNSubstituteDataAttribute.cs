using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace GqlPlus;

internal sealed class AutoNSubstituteDataAttribute : AutoDataAttribute
{
  public AutoNSubstituteDataAttribute()
      : base(() => new Fixture()
        .Customize(new AutoNSubstituteCustomization())
        .Customize(new TestsCustomizations()))
  { }
}
