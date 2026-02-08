//HintName: test_alt-mod-param+Input_Impl.gen.cs
// Generated from alt-mod-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public class testAltModParamInp<Tmod>
  : ItestAltModParamInp<Tmod>
{
  public IDictionary<Tmod, ItestAltAltModParamInp> AsAltAltModParamInp { get; set; }
}

public class testAltAltModParamInp
  : ItestAltAltModParamInp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}
