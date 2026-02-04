//HintName: test_alt-mod-param+Dual_Impl.gen.cs
// Generated from alt-mod-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public class testAltModParamDual<Tmod>
  : ItestAltModParamDual<Tmod>
{
  public IDictionary<Tmod, testAltAltModParamDual> AsAltAltModParamDual { get; set; }
  public testAltModParamDual AltModParamDual { get; set; }
}

public class testAltAltModParamDual
  : ItestAltAltModParamDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltAltModParamDual AltAltModParamDual { get; set; }
}
