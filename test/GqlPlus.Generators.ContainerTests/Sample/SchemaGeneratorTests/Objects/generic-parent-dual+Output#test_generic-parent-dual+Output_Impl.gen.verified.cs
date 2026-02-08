//HintName: test_generic-parent-dual+Output_Impl.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public class testGnrcPrntDualOutp
  : testRefGnrcPrntDualOutp
  , ItestGnrcPrntDualOutp
{
  public ItestGnrcPrntDualOutpObject AsGnrcPrntDualOutp { get; set; }
}

public class testRefGnrcPrntDualOutp<Tref>
  : ItestRefGnrcPrntDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntDualOutpObject AsRefGnrcPrntDualOutp { get; set; }
}

public class testAltGnrcPrntDualOutp
  : ItestAltGnrcPrntDualOutp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltGnrcPrntDualOutpObject AsAltGnrcPrntDualOutp { get; set; }
}
