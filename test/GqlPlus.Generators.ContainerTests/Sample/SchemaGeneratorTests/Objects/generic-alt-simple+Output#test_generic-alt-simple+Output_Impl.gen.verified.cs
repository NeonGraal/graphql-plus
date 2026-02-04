//HintName: test_generic-alt-simple+Output_Impl.gen.cs
// Generated from generic-alt-simple+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public class testGnrcAltSmplOutp
  : ItestGnrcAltSmplOutp
{
  public testRefGnrcAltSmplOutp<testString> AsRefGnrcAltSmplOutp { get; set; }
  public testGnrcAltSmplOutp GnrcAltSmplOutp { get; set; }
}

public class testRefGnrcAltSmplOutp<Tref>
  : ItestRefGnrcAltSmplOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltSmplOutp RefGnrcAltSmplOutp { get; set; }
}
