//HintName: test_generic-alt-dual+Input_Intf.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public interface ItestGnrcAltDualInp
{
  public testRefGnrcAltDualInp<testAltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
  public testGnrcAltDualInp GnrcAltDualInp { get; set; }
}

public interface ItestGnrcAltDualInpObject
{
}

public interface ItestRefGnrcAltDualInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltDualInp RefGnrcAltDualInp { get; set; }
}

public interface ItestRefGnrcAltDualInpObject<Tref>
{
}

public interface ItestAltGnrcAltDualInp
{
  public testString AsString { get; set; }
  public testAltGnrcAltDualInp AltGnrcAltDualInp { get; set; }
}

public interface ItestAltGnrcAltDualInpObject
{
  public testNumber alt { get; set; }
}
