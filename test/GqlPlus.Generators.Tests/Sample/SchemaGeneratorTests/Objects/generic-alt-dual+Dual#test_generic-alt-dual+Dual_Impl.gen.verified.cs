//HintName: test_generic-alt-dual+Dual_Impl.gen.cs
// Generated from generic-alt-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public class testGnrcAltDualDual
  : ItestGnrcAltDualDual
{
  public RefGnrcAltDualDual<AltGnrcAltDualDual> AsRefGnrcAltDualDual { get; set; }
}

public class testRefGnrcAltDualDual<Tref>
  : ItestRefGnrcAltDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcAltDualDual
  : ItestAltGnrcAltDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
