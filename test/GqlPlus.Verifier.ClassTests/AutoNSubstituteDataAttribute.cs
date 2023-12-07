﻿using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace GqlPlus.Verifier;

internal sealed class AutoNSubstituteDataAttribute : AutoDataAttribute
{
  public AutoNSubstituteDataAttribute()
      : base(() => new Fixture()
        .Customize(new AutoNSubstituteCustomization())
        .Customize(new TestsCustomizations()))
  { }
}
