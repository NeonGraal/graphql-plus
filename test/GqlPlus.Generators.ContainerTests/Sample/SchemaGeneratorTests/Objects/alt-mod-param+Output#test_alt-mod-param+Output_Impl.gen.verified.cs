//HintName: test_alt-mod-param+Output_Impl.gen.cs
// Generated from alt-mod-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public class testAltModParamOutp<Tmod>
  : ItestAltModParamOutp<Tmod>
{
  public IDictionary<Tmod, ItestAltAltModParamOutp> AsAltAltModParamOutp { get; set; }
  public ItestAltModParamOutpObject AsAltModParamOutp { get; set; }
}

public class testAltAltModParamOutp
  : ItestAltAltModParamOutp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltAltModParamOutpObject AsAltAltModParamOutp { get; set; }
}
