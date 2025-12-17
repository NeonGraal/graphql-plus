//HintName: test_generic-alt-simple+Input_Intf.gen.cs
// Generated from generic-alt-simple+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public interface ItestGnrcAltSmplInp
{
  public testRefGnrcAltSmplInp<testString> AsRefGnrcAltSmplInp { get; set; }
  public testGnrcAltSmplInp GnrcAltSmplInp { get; set; }
}

public interface ItestGnrcAltSmplInpField
{
}

public interface ItestRefGnrcAltSmplInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltSmplInp RefGnrcAltSmplInp { get; set; }
}

public interface ItestRefGnrcAltSmplInpField<Tref>
{
}
