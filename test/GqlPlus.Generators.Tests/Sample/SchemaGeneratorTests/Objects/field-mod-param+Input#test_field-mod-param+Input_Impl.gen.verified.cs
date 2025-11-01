//HintName: test_field-mod-param+Input_Impl.gen.cs
// Generated from field-mod-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public class testFieldModParamInp<Tmod>
  : ItestFieldModParamInp<Tmod>
{
  public IDictionary<Tmod, testFldFieldModParamInp> field { get; set; }
  public testFieldModParamInp FieldModParamInp { get; set; }
}

public class testFldFieldModParamInp
  : ItestFldFieldModParamInp
{
  public testNumber field { get; set; }
  public testString AsString { get; set; }
  public testFldFieldModParamInp FldFieldModParamInp { get; set; }
}
