//HintName: test_alt-mod-param+Input_Impl.gen.cs
// Generated from alt-mod-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public class testAltModParamInp<Tmod>
  : ItestAltModParamInp<Tmod>
{
  public IDictionary<Tmod, testAltAltModParamInp> AsAltAltModParamInp { get; set; }
  public testAltModParamInp AltModParamInp { get; set; }
}

public class testAltAltModParamInp
  : ItestAltAltModParamInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltAltModParamInp AltAltModParamInp { get; set; }
}
