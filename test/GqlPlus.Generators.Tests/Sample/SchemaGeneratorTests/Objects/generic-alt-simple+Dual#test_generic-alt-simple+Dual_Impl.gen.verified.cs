//HintName: test_generic-alt-simple+Dual_Impl.gen.cs
// Generated from generic-alt-simple+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public class testGnrcAltSmplDual
  : ItestGnrcAltSmplDual
{
  public testRefGnrcAltSmplDual<testString> AsRefGnrcAltSmplDual { get; set; }
  public testGnrcAltSmplDual GnrcAltSmplDual { get; set; }
}

public class testRefGnrcAltSmplDual<Tref>
  : ItestRefGnrcAltSmplDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltSmplDual RefGnrcAltSmplDual { get; set; }
}
