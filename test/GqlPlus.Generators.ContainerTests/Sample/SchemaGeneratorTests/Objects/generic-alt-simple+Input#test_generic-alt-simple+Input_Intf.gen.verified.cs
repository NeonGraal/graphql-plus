//HintName: test_generic-alt-simple+Input_Intf.gen.cs
// Generated from generic-alt-simple+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public interface ItestGnrcAltSmplInp
{
  public ItestRefGnrcAltSmplInp<ItestString> AsRefGnrcAltSmplInp { get; set; }
  public ItestGnrcAltSmplInpObject AsGnrcAltSmplInp { get; set; }
}

public interface ItestGnrcAltSmplInpObject
{
}

public interface ItestRefGnrcAltSmplInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltSmplInpObject AsRefGnrcAltSmplInp { get; set; }
}

public interface ItestRefGnrcAltSmplInpObject<Tref>
{
}
