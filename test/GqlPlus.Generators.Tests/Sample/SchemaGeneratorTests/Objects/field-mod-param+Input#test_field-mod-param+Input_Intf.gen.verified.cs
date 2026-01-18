//HintName: test_field-mod-param+Input_Intf.gen.cs
// Generated from field-mod-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public interface ItestFieldModParamInp<Tmod>
{
  public testFieldModParamInp FieldModParamInp { get; set; }
}

public interface ItestFieldModParamInpField<Tmod>
{
  public IDictionary<Tmod, testFldFieldModParamInp> field { get; set; }
}

public interface ItestFldFieldModParamInp
{
  public testString AsString { get; set; }
  public testFldFieldModParamInp FldFieldModParamInp { get; set; }
}

public interface ItestFldFieldModParamInpField
{
  public testNumber field { get; set; }
}
