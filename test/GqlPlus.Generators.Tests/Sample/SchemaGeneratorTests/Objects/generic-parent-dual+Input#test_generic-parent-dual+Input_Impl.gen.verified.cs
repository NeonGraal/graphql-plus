//HintName: test_generic-parent-dual+Input_Impl.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public class testGnrcPrntDualInp
  : testRefGnrcPrntDualInp
  , ItestGnrcPrntDualInp
{
}

public class testRefGnrcPrntDualInp<Tref>
  : ItestRefGnrcPrntDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcPrntDualInp
  : ItestAltGnrcPrntDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
