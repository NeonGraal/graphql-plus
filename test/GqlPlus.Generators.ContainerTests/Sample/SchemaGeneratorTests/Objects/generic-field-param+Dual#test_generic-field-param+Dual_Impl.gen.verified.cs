//HintName: test_generic-field-param+Dual_Impl.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public class testGnrcFieldParamDual
  : ItestGnrcFieldParamDual
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }
}

public class testRefGnrcFieldParamDual<Tref>
  : ItestRefGnrcFieldParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcFieldParamDual
  : ItestAltGnrcFieldParamDual
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}
