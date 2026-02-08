//HintName: test_field-mod-param+Input_Impl.gen.cs
// Generated from field-mod-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public class testFieldModParamInp<Tmod>
  : ItestFieldModParamInp<Tmod>
{
  public IDictionary<Tmod, ItestFldFieldModParamInp> Field { get; set; }
  public ItestFieldModParamInpObject AsFieldModParamInp { get; set; }
}

public class testFldFieldModParamInp
  : ItestFldFieldModParamInp
{
  public ItestNumber Field { get; set; }
  public ItestString AsString { get; set; }
  public ItestFldFieldModParamInpObject AsFldFieldModParamInp { get; set; }
}
