//HintName: test_field-mod-param+Output_Impl.gen.cs
// Generated from field-mod-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public class testFieldModParamOutp<TMod>
  : ItestFieldModParamOutp<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; set; }
  public ItestFieldModParamOutpObject<TMod> AsFieldModParamOutp { get; set; }
}

public class testFldFieldModParamOutp
  : ItestFldFieldModParamOutp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldModParamOutpObject AsFldFieldModParamOutp { get; set; }
}
