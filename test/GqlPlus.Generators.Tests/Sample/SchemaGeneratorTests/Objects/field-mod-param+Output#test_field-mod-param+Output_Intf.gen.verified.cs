//HintName: test_field-mod-param+Output_Intf.gen.cs
// Generated from field-mod-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public interface ItestFieldModParamOutp<Tmod>
{
  public testFieldModParamOutp FieldModParamOutp { get; set; }
}

public interface ItestFieldModParamOutpField<Tmod>
{
  public IDictionary<Tmod, testFldFieldModParamOutp> field { get; set; }
}

public interface ItestFldFieldModParamOutp
{
  public testString AsString { get; set; }
  public testFldFieldModParamOutp FldFieldModParamOutp { get; set; }
}

public interface ItestFldFieldModParamOutpField
{
  public testNumber field { get; set; }
}
