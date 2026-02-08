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

public class testRefGnrcAltDualOutp<Tref>
  : ItestRefGnrcAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltDualOutpObject AsRefGnrcAltDualOutp { get; set; }
}

public class testAltGnrcAltDualOutp
  : ItestAltGnrcAltDualOutp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltGnrcAltDualOutpObject AsAltGnrcAltDualOutp { get; set; }
}
