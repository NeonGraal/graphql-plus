//HintName: test_generic-alt-param+Dual_Impl.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public class testGnrcAltParamDual
  : ItestGnrcAltParamDual
{
}

public class testRefGnrcAltParamDual<TRef>
  : ItestRefGnrcAltParamDual<TRef>
{
}

public class testAltGnrcAltParamDual
  : ItestAltGnrcAltParamDual
{
  public decimal Alt { get; set; }
}
