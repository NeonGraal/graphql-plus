//HintName: test_generic-alt-param+Dual_Impl.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public class testGnrcAltParamDual
  : ItestGnrcAltParamDual
{
  public ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
  public ItestGnrcAltParamDualObject AsGnrcAltParamDual { get; set; }
}

public class testRefGnrcAltParamDual<Tref>
  : ItestRefGnrcAltParamDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltParamDualObject AsRefGnrcAltParamDual { get; set; }
}

public class testAltGnrcAltParamDual
  : ItestAltGnrcAltParamDual
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltGnrcAltParamDualObject AsAltGnrcAltParamDual { get; set; }
}
