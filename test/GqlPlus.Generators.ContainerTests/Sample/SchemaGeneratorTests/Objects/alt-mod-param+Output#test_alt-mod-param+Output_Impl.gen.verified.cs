//HintName: test_alt-mod-param+Output_Impl.gen.cs
// Generated from alt-mod-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public class testAltModParamOutp<Tmod>
  : ItestAltModParamOutp<Tmod>
{
  public IDictionary<Tmod, testAltAltModParamOutp> AsAltAltModParamOutp { get; set; }
  public testAltModParamOutp AltModParamOutp { get; set; }
}

public class testAltAltModParamOutp
  : ItestAltAltModParamOutp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltAltModParamOutp AltAltModParamOutp { get; set; }
}
