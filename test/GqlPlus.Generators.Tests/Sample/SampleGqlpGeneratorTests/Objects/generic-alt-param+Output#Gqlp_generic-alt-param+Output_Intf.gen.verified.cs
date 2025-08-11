//HintName: Gqlp_generic-alt-param+Output_Intf.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_param_Output;

public interface IGnrcAltParamOutp
{
  RefGnrcAltParamOutp<AltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; }
}

public interface IRefGnrcAltParamOutp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcAltParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
