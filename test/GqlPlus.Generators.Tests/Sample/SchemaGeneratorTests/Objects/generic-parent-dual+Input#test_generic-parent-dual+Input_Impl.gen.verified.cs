//HintName: test_generic-parent-dual+Input_Impl.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public class testGnrcPrntDualInp
  : testRefGnrcPrntDualInp
  , ItestGnrcPrntDualInp
{
  public testGnrcPrntDualInp GnrcPrntDualInp { get; set; }
}

public class testRefGnrcPrntDualInp<Tref>
  : ItestRefGnrcPrntDualInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntDualInp RefGnrcPrntDualInp { get; set; }
}

public class testAltGnrcPrntDualInp
  : ItestAltGnrcPrntDualInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntDualInp AltGnrcPrntDualInp { get; set; }
}
