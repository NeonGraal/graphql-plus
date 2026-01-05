//HintName: test_generic-alt-simple+Dual_Intf.gen.cs
// Generated from generic-alt-simple+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public interface ItestGnrcAltSmplDual
{
  public testRefGnrcAltSmplDual<testString> AsRefGnrcAltSmplDual { get; set; }
  public testGnrcAltSmplDual GnrcAltSmplDual { get; set; }
}

public interface ItestGnrcAltSmplDualField
{
}

public interface ItestRefGnrcAltSmplDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltSmplDual RefGnrcAltSmplDual { get; set; }
}

public interface ItestRefGnrcAltSmplDualField<Tref>
{
}
