//HintName: test_alt-mod-param+Output_Intf.gen.cs
// Generated from alt-mod-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public interface ItestAltModParamOutp<Tmod>
{
  public IDictionary<Tmod, ItestAltAltModParamOutp> AsAltAltModParamOutp { get; set; }
  public ItestAltModParamOutpObject AsAltModParamOutp { get; set; }
}

public interface ItestAltModParamOutpObject<Tmod>
{
}

public interface ItestAltAltModParamOutp
{
  public string AsString { get; set; }
  public ItestAltAltModParamOutpObject AsAltAltModParamOutp { get; set; }
}

public interface ItestAltAltModParamOutpObject
{
  public decimal Alt { get; set; }
}
