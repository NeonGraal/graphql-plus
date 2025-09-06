//HintName: Gqlp_alt-mod-param+Input_Impl.gen.cs
// Generated from alt-mod-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_alt_mod_param_Input;

public class InputAltModParamInp<Tmod>
  : IAltModParamInp<Tmod>
{
  public AltAltModParamInp AsAltAltModParamInp { get; set; }
}

public class InputAltAltModParamInp
  : IAltAltModParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
