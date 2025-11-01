//HintName: test_field-mod-param+Output_Impl.gen.cs
// Generated from field-mod-param+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public class testFieldModParamOutp<Tmod>
  : ItestFieldModParamOutp<Tmod>
{
  public IDictionary<Tmod, testFldFieldModParamOutp> field { get; set; }
  public testFieldModParamOutp FieldModParamOutp { get; set; }
}

public class testFldFieldModParamOutp
  : ItestFldFieldModParamOutp
{
  public testNumber field { get; set; }
  public testString AsString { get; set; }
  public testFldFieldModParamOutp FldFieldModParamOutp { get; set; }
}
