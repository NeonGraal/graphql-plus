//HintName: Model_alt-mod-param+Input.gen.cs
// Generated from alt-mod-param+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_alt_mod_param_Input;

public interface IAltModParamInp<Tmod>
{
  AltAltModParamInp AsAltAltModParamInp { get; }
}
public class InputAltModParamInp<Tmod>
  : IAltModParamInp<Tmod>
{
  public AltAltModParamInp AsAltAltModParamInp { get; set; }
}

public interface IAltAltModParamInp
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltAltModParamInp
  : IAltAltModParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
