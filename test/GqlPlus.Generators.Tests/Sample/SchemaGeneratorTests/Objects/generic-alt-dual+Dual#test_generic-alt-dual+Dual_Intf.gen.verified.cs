//HintName: test_generic-alt-dual+Dual_Intf.gen.cs
// Generated from generic-alt-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public interface ItestGnrcAltDualDual
{
  public testRefGnrcAltDualDual<testAltGnrcAltDualDual> AsRefGnrcAltDualDual { get; set; }
  public testGnrcAltDualDual GnrcAltDualDual { get; set; }
}

public interface ItestGnrcAltDualDualField
{
}

public interface ItestRefGnrcAltDualDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltDualDual RefGnrcAltDualDual { get; set; }
}

public interface ItestRefGnrcAltDualDualField<Tref>
{
}

public interface ItestAltGnrcAltDualDual
{
  public testString AsString { get; set; }
  public testAltGnrcAltDualDual AltGnrcAltDualDual { get; set; }
}

public interface ItestAltGnrcAltDualDualField
{
  public testNumber alt { get; set; }
}
