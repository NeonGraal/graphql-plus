//HintName: test_generic-alt-dual+Output_Impl.gen.cs
// Generated from generic-alt-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public class testGnrcAltDualOutp
  : ItestGnrcAltDualOutp
{
  public testRefGnrcAltDualOutp<testAltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; set; }
  public testGnrcAltDualOutp GnrcAltDualOutp { get; set; }
}

public class testRefGnrcAltDualOutp<Tref>
  : ItestRefGnrcAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltDualOutp RefGnrcAltDualOutp { get; set; }
}

public class testAltGnrcAltDualOutp
  : ItestAltGnrcAltDualOutp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcAltDualOutp AltGnrcAltDualOutp { get; set; }
}
