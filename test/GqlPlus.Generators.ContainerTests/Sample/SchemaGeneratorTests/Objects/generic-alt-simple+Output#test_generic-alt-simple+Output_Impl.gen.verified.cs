//HintName: test_generic-alt-simple+Output_Impl.gen.cs
// Generated from generic-alt-simple+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public class testGnrcAltSmplOutp
  : ItestGnrcAltSmplOutp
{
  public ItestRefGnrcAltSmplOutp<string> AsRefGnrcAltSmplOutp { get; set; }
  public ItestGnrcAltSmplOutpObject AsGnrcAltSmplOutp { get; set; }
}

public class testRefGnrcAltSmplOutp<Tref>
  : ItestRefGnrcAltSmplOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltSmplOutpObject AsRefGnrcAltSmplOutp { get; set; }
}
