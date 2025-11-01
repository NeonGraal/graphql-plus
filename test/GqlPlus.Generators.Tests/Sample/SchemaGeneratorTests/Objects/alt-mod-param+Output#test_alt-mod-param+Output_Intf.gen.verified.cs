//HintName: test_alt-mod-param+Output_Intf.gen.cs
// Generated from alt-mod-param+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public interface ItestAltModParamOutp<Tmod>
{
  public IDictionary<Tmod, testAltAltModParamOutp> AsAltAltModParamOutp { get; set; }
  public testAltModParamOutp AltModParamOutp { get; set; }
}

public interface ItestAltModParamOutpField<Tmod>
{
}

public interface ItestAltAltModParamOutp
{
  public testString AsString { get; set; }
  public testAltAltModParamOutp AltAltModParamOutp { get; set; }
}

public interface ItestAltAltModParamOutpField
{
  public testNumber alt { get; set; }
}
