//HintName: test_generic-alt-param+Dual_Intf.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public interface ItestGnrcAltParamDual
{
  public testRefGnrcAltParamDual<testAltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
  public testGnrcAltParamDual GnrcAltParamDual { get; set; }
}

public interface ItestGnrcAltParamDualField
{
}

public interface ItestRefGnrcAltParamDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltParamDual RefGnrcAltParamDual { get; set; }
}

public interface ItestRefGnrcAltParamDualField<Tref>
{
}

public interface ItestAltGnrcAltParamDual
{
  public testString AsString { get; set; }
  public testAltGnrcAltParamDual AltGnrcAltParamDual { get; set; }
}

public interface ItestAltGnrcAltParamDualField
{
  public testNumber alt { get; set; }
}
