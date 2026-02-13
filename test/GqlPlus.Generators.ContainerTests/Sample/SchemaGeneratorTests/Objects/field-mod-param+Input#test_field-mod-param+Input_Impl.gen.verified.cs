//HintName: test_field-mod-param+Input_Impl.gen.cs
// Generated from field-mod-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public class testFieldModParamInp<TMod>
  : ItestFieldModParamInp<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamInp> Field { get; set; }
  public ItestFieldModParamInpObject<TMod> AsFieldModParamInp { get; set; }
}

public class testFldFieldModParamInp
  : ItestFldFieldModParamInp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldModParamInpObject AsFldFieldModParamInp { get; set; }
}
