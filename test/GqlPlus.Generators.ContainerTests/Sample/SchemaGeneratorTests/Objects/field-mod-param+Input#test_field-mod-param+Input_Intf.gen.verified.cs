//HintName: test_field-mod-param+Input_Intf.gen.cs
// Generated from field-mod-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public interface ItestFieldModParamInp<Tmod>
{
}

public interface ItestFieldModParamInpObject<Tmod>
{
  public IDictionary<Tmod, ItestFldFieldModParamInp> Field { get; set; }
}

public interface ItestFldFieldModParamInp
{
  public ItestString AsString { get; set; }
}

public interface ItestFldFieldModParamInpObject
{
  public ItestNumber Field { get; set; }
}
