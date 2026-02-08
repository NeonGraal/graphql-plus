//HintName: test_field-mod-param+Output_Intf.gen.cs
// Generated from field-mod-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public interface ItestFieldModParamOutp<Tmod>
{
}

public interface ItestFieldModParamOutpObject<Tmod>
{
  public IDictionary<Tmod, ItestFldFieldModParamOutp> Field { get; set; }
}

public interface ItestFldFieldModParamOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestFldFieldModParamOutpObject
{
  public ItestNumber Field { get; set; }
}
