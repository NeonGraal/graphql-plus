//HintName: test_alt-mod-param+Input_Intf.gen.cs
// Generated from alt-mod-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public interface ItestAltModParamInp<Tmod>
{
  public IDictionary<Tmod, ItestAltAltModParamInp> AsAltAltModParamInp { get; set; }
  public ItestAltModParamInpObject AsAltModParamInp { get; set; }
}

public interface ItestAltModParamInpObject<Tmod>
{
}

public interface ItestAltAltModParamInp
{
  public ItestString AsString { get; set; }
  public ItestAltAltModParamInpObject AsAltAltModParamInp { get; set; }
}

public interface ItestAltAltModParamInpObject
{
  public ItestNumber Alt { get; set; }
}
