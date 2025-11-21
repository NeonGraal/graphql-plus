//HintName: test_generic-alt-param+Dual_Impl.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public class testGnrcAltParamDual
  : ItestGnrcAltParamDual
{
  public testRefGnrcAltParamDual<testAltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
  public testGnrcAltParamDual GnrcAltParamDual { get; set; }
}

public class testRefGnrcAltParamDual<Tref>
  : ItestRefGnrcAltParamDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltParamDual RefGnrcAltParamDual { get; set; }
}

public class testAltGnrcAltParamDual
  : ItestAltGnrcAltParamDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcAltParamDual AltGnrcAltParamDual { get; set; }
}
