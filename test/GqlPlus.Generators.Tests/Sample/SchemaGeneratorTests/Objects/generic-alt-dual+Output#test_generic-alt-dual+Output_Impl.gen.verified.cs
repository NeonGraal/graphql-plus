﻿//HintName: test_generic-alt-dual+Output_Impl.gen.cs
// Generated from generic-alt-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public class testGnrcAltDualOutp
  : ItestGnrcAltDualOutp
{
  public RefGnrcAltDualOutp<AltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; set; }
}

public class testRefGnrcAltDualOutp<Tref>
  : ItestRefGnrcAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcAltDualOutp
  : ItestAltGnrcAltDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
