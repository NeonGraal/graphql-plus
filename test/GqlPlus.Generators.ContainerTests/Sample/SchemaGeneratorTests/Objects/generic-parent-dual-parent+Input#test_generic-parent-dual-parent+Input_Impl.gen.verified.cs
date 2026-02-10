//HintName: test_generic-parent-dual-parent+Input_Impl.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public class testGnrcPrntDualPrntInp
  : testRefGnrcPrntDualPrntInp
  , ItestGnrcPrntDualPrntInp
{
  public ItestGnrcPrntDualPrntInpObject AsGnrcPrntDualPrntInp { get; set; }
}

public class testRefGnrcPrntDualPrntInp<Tref>
  : testref
  , ItestRefGnrcPrntDualPrntInp<Tref>
{
  public ItestRefGnrcPrntDualPrntInpObject AsRefGnrcPrntDualPrntInp { get; set; }
}

public class testAltGnrcPrntDualPrntInp
  : ItestAltGnrcPrntDualPrntInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualPrntInpObject AsAltGnrcPrntDualPrntInp { get; set; }
}
