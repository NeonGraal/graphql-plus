//HintName: test_field-mod-param+Output_Impl.gen.cs
// Generated from field-mod-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public class testFieldModParamOutp<Tmod>
  : ItestFieldModParamOutp<Tmod>
{
  public IDictionary<Tmod, ItestFldFieldModParamOutp> Field { get; set; }
}

public class testFldFieldModParamOutp
  : ItestFldFieldModParamOutp
{
  public ItestNumber Field { get; set; }
  public ItestString AsString { get; set; }
}
