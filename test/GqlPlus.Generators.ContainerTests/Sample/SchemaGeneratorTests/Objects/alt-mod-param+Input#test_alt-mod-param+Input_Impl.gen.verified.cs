//HintName: test_alt-mod-param+Input_Impl.gen.cs
// Generated from alt-mod-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public class testAltModParamInp<TMod>
  : ItestAltModParamInp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamInp> AsAltAltModParamInp { get; set; }
  public ItestAltModParamInpObject AsAltModParamInp { get; set; }
}

public class testAltAltModParamInp
  : ItestAltAltModParamInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModParamInpObject AsAltAltModParamInp { get; set; }
}
