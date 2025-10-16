//HintName: test_generic-alt-dual+Input_Impl.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public class testGnrcAltDualInp
  : ItestGnrcAltDualInp
{
  public RefGnrcAltDualInp<AltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
}

public class testRefGnrcAltDualInp<Tref>
  : ItestRefGnrcAltDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcAltDualInp
  : ItestAltGnrcAltDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
