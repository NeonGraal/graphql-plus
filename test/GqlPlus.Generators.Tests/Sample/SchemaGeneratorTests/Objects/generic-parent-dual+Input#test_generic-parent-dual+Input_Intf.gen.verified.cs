//HintName: test_generic-parent-dual+Input_Intf.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public interface ItestGnrcPrntDualInp
  : ItestRefGnrcPrntDualInp
{
  public testGnrcPrntDualInp GnrcPrntDualInp { get; set; }
}

public interface ItestGnrcPrntDualInpField
  : ItestRefGnrcPrntDualInpField
{
}

public interface ItestRefGnrcPrntDualInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntDualInp RefGnrcPrntDualInp { get; set; }
}

public interface ItestRefGnrcPrntDualInpField<Tref>
{
}

public interface ItestAltGnrcPrntDualInp
{
  public testString AsString { get; set; }
  public testAltGnrcPrntDualInp AltGnrcPrntDualInp { get; set; }
}

public interface ItestAltGnrcPrntDualInpField
{
  public testNumber alt { get; set; }
}
