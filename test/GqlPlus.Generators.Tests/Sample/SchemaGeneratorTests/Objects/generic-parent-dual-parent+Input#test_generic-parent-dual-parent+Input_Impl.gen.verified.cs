//HintName: test_generic-parent-dual-parent+Input_Impl.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public class testGnrcPrntDualPrntInp
  : testRefGnrcPrntDualPrntInp
  , ItestGnrcPrntDualPrntInp
{
}

public class testRefGnrcPrntDualPrntInp<Tref>
  : testref
  , ItestRefGnrcPrntDualPrntInp<Tref>
{
}

public class testAltGnrcPrntDualPrntInp
  : ItestAltGnrcPrntDualPrntInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
