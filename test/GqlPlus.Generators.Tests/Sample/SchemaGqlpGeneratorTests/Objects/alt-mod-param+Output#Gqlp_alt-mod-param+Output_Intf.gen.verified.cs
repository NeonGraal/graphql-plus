//HintName: Gqlp_alt-mod-param+Output_Intf.gen.cs
// Generated from alt-mod-param+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_alt_mod_param_Output;

public interface IAltModParamOutp<Tmod>
{
  AltAltModParamOutp AsAltAltModParamOutp { get; }
}

public interface IAltAltModParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
