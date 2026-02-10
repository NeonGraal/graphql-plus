//HintName: test_field-mod-param+Output_Intf.gen.cs
// Generated from field-mod-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public interface ItestFieldModParamOutp<Tmod>
{
  public ItestFieldModParamOutpObject AsFieldModParamOutp { get; set; }
}

public interface ItestFieldModParamOutpObject<Tmod>
{
  public IDictionary<Tmod, ItestFldFieldModParamOutp> Field { get; set; }
}

public interface ItestFldFieldModParamOutp
{
  public string AsString { get; set; }
  public ItestFldFieldModParamOutpObject AsFldFieldModParamOutp { get; set; }
}

public interface ItestFldFieldModParamOutpObject
{
  public decimal Field { get; set; }
}
