//HintName: test_generic-parent-dual-parent+Input_Impl.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public class testGnrcPrntDualPrntInp
  : testRefGnrcPrntDualPrntInp
  , ItestGnrcPrntDualPrntInp
{
  public testGnrcPrntDualPrntInp GnrcPrntDualPrntInp { get; set; }
}

public class testRefGnrcPrntDualPrntInp<Tref>
  : testref
  , ItestRefGnrcPrntDualPrntInp<Tref>
{
  public testRefGnrcPrntDualPrntInp RefGnrcPrntDualPrntInp { get; set; }
}

public class testAltGnrcPrntDualPrntInp
  : ItestAltGnrcPrntDualPrntInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntDualPrntInp AltGnrcPrntDualPrntInp { get; set; }
}
