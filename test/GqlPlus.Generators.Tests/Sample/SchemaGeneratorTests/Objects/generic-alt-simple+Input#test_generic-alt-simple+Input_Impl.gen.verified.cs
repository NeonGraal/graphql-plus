//HintName: test_generic-alt-simple+Input_Impl.gen.cs
// Generated from generic-alt-simple+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public class InputtestGnrcAltSmplInp
  : ItestGnrcAltSmplInp
{
  public RefGnrcAltSmplInp<String> AsRefGnrcAltSmplInp { get; set; }
}

public class InputtestRefGnrcAltSmplInp<Tref>
  : ItestRefGnrcAltSmplInp<Tref>
{
  public Tref Asref { get; set; }
}
