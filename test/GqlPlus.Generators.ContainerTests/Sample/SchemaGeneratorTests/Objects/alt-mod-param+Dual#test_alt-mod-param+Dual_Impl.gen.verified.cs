//HintName: test_alt-mod-param+Dual_Impl.gen.cs
// Generated from alt-mod-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public class testAltModParamDual<Tmod>
  : ItestAltModParamDual<Tmod>
{
  public IDictionary<Tmod, ItestAltAltModParamDual> AsAltAltModParamDual { get; set; }
  public ItestAltModParamDualObject AsAltModParamDual { get; set; }
}

public class testAltAltModParamDual
  : ItestAltAltModParamDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModParamDualObject AsAltAltModParamDual { get; set; }
}
