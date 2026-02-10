//HintName: test_generic-alt-simple+Input_Impl.gen.cs
// Generated from generic-alt-simple+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public class testGnrcAltSmplInp
  : ItestGnrcAltSmplInp
{
  public ItestRefGnrcAltSmplInp<string> AsRefGnrcAltSmplInp { get; set; }
  public ItestGnrcAltSmplInpObject AsGnrcAltSmplInp { get; set; }
}

public class testRefGnrcAltSmplInp<Tref>
  : ItestRefGnrcAltSmplInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltSmplInpObject AsRefGnrcAltSmplInp { get; set; }
}
