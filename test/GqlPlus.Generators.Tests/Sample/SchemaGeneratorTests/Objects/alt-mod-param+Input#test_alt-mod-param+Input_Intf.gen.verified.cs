//HintName: test_alt-mod-param+Input_Intf.gen.cs
// Generated from alt-mod-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public interface ItestAltModParamInp<Tmod>
{
  public IDictionary<Tmod, testAltAltModParamInp> AsAltAltModParamInp { get; set; }
  public testAltModParamInp AltModParamInp { get; set; }
}

public interface ItestAltModParamInpField<Tmod>
{
}

public interface ItestAltAltModParamInp
{
  public testString AsString { get; set; }
  public testAltAltModParamInp AltAltModParamInp { get; set; }
}

public interface ItestAltAltModParamInpField
{
  public testNumber alt { get; set; }
}
