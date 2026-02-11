//HintName: test_generic-alt-dual+Output_Impl.gen.cs
// Generated from generic-alt-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public class testGnrcAltDualOutp
  : ItestGnrcAltDualOutp
{
  public ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; set; }
  public ItestGnrcAltDualOutpObject AsGnrcAltDualOutp { get; set; }
}

public class testRefGnrcAltDualOutp<TRef>
  : ItestRefGnrcAltDualOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltDualOutpObject AsRefGnrcAltDualOutp { get; set; }
}

public class testAltGnrcAltDualOutp
  : ItestAltGnrcAltDualOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltDualOutpObject AsAltGnrcAltDualOutp { get; set; }
}
