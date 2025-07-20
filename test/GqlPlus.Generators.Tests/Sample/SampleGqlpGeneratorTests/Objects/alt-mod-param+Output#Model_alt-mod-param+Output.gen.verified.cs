//HintName: Model_alt-mod-param+Output.gen.cs
// Generated from alt-mod-param+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_alt_mod_param_Output;

public interface IAltModParamOutp<Tmod>
{
  AltAltModParamOutp AsAltAltModParamOutp { get; }
}
public class OutputAltModParamOutp<Tmod>
  : IAltModParamOutp<Tmod>
{
  public AltAltModParamOutp AsAltAltModParamOutp { get; set; }
}

public interface IAltAltModParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltAltModParamOutp
  : IAltAltModParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
