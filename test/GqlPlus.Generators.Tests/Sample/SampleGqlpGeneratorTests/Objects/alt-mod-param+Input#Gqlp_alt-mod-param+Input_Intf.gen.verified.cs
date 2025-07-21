//HintName: Gqlp_alt-mod-param+Input_Intf.gen.cs
// Generated from alt-mod-param+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_alt_mod_param_Input;

public interface IAltModParamInp<Tmod>
{
  AltAltModParamInp AsAltAltModParamInp { get; }
}

public interface IAltAltModParamInp
{
  Number alt { get; }
  String AsString { get; }
}
