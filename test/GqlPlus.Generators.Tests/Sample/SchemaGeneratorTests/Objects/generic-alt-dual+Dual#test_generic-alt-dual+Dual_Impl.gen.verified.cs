//HintName: test_generic-alt-dual+Dual_Impl.gen.cs
// Generated from generic-alt-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public class testGnrcAltDualDual
  : ItestGnrcAltDualDual
{
  public testRefGnrcAltDualDual<testAltGnrcAltDualDual> AsRefGnrcAltDualDual { get; set; }
  public testGnrcAltDualDual GnrcAltDualDual { get; set; }
}

public class testRefGnrcAltDualDual<Tref>
  : ItestRefGnrcAltDualDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltDualDual RefGnrcAltDualDual { get; set; }
}

public class testAltGnrcAltDualDual
  : ItestAltGnrcAltDualDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcAltDualDual AltGnrcAltDualDual { get; set; }
}
