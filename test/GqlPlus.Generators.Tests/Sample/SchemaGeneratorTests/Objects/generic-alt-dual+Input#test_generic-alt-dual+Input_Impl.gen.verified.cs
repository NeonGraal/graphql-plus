//HintName: test_generic-alt-dual+Input_Impl.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public class InputtestGnrcAltDualInp
  : ItestGnrcAltDualInp
{
  public RefGnrcAltDualInp<AltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
}

public class InputtestRefGnrcAltDualInp<Tref>
  : ItestRefGnrcAltDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestAltGnrcAltDualInp
  : ItestAltGnrcAltDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
