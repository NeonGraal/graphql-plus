//HintName: test_generic-alt-dual+Input_Impl.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public class testGnrcAltDualInp
  : ItestGnrcAltDualInp
{
  public testRefGnrcAltDualInp<testAltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
  public testGnrcAltDualInp GnrcAltDualInp { get; set; }
}

public class testRefGnrcAltDualInp<Tref>
  : ItestRefGnrcAltDualInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltDualInp RefGnrcAltDualInp { get; set; }
}

public class testAltGnrcAltDualInp
  : ItestAltGnrcAltDualInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcAltDualInp AltGnrcAltDualInp { get; set; }
}
