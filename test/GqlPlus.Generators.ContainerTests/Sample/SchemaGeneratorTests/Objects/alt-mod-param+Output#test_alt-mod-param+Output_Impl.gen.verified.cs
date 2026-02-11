//HintName: test_alt-mod-param+Output_Impl.gen.cs
// Generated from alt-mod-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public class testAltModParamOutp<TMod>
  : ItestAltModParamOutp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamOutp> AsAltAltModParamOutp { get; set; }
  public ItestAltModParamOutpObject AsAltModParamOutp { get; set; }
}

public class testAltAltModParamOutp
  : ItestAltAltModParamOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModParamOutpObject AsAltAltModParamOutp { get; set; }
}
