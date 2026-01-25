//HintName: test_generic-parent-dual-parent+Input_Intf.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public interface ItestGnrcPrntDualPrntInp
  : ItestRefGnrcPrntDualPrntInp
{
  public testGnrcPrntDualPrntInp GnrcPrntDualPrntInp { get; set; }
}

public interface ItestGnrcPrntDualPrntInpObject
  : ItestRefGnrcPrntDualPrntInpObject
{
}

public interface ItestRefGnrcPrntDualPrntInp<Tref>
  : Itestref
{
  public testRefGnrcPrntDualPrntInp RefGnrcPrntDualPrntInp { get; set; }
}

public interface ItestRefGnrcPrntDualPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntDualPrntInp
{
  public testString AsString { get; set; }
  public testAltGnrcPrntDualPrntInp AltGnrcPrntDualPrntInp { get; set; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
{
  public testNumber alt { get; set; }
}
