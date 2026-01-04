//HintName: test_generic-field-param+Dual_Intf.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public interface ItestGnrcFieldParamDual
{
  public testGnrcFieldParamDual GnrcFieldParamDual { get; set; }
}

public interface ItestGnrcFieldParamDualField
{
  public testRefGnrcFieldParamDual<testAltGnrcFieldParamDual> field { get; set; }
}

public interface ItestRefGnrcFieldParamDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldParamDual RefGnrcFieldParamDual { get; set; }
}

public interface ItestRefGnrcFieldParamDualField<Tref>
{
}

public interface ItestAltGnrcFieldParamDual
{
  public testString AsString { get; set; }
  public testAltGnrcFieldParamDual AltGnrcFieldParamDual { get; set; }
}

public interface ItestAltGnrcFieldParamDualField
{
  public testNumber alt { get; set; }
}
