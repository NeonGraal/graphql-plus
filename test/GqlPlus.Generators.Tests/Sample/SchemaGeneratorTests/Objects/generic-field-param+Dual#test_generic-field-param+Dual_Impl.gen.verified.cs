//HintName: test_generic-field-param+Dual_Impl.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public class testGnrcFieldParamDual
  : ItestGnrcFieldParamDual
{
  public testRefGnrcFieldParamDual<testAltGnrcFieldParamDual> field { get; set; }
  public testGnrcFieldParamDual GnrcFieldParamDual { get; set; }
}

public class testRefGnrcFieldParamDual<Tref>
  : ItestRefGnrcFieldParamDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldParamDual RefGnrcFieldParamDual { get; set; }
}

public class testAltGnrcFieldParamDual
  : ItestAltGnrcFieldParamDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcFieldParamDual AltGnrcFieldParamDual { get; set; }
}
