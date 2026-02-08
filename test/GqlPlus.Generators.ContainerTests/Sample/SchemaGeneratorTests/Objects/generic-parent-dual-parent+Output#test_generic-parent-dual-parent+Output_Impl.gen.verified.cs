//HintName: test_generic-parent-dual-parent+Output_Impl.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public class testGnrcPrntDualPrntOutp
  : testRefGnrcPrntDualPrntOutp
  , ItestGnrcPrntDualPrntOutp
{
}

public class testRefGnrcPrntDualPrntOutp<Tref>
  : testref
  , ItestRefGnrcPrntDualPrntOutp<Tref>
{
}

public class testAltGnrcPrntDualPrntOutp
  : ItestAltGnrcPrntDualPrntOutp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}
