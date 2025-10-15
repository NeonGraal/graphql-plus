//HintName: test_generic-alt-param+Output_Intf.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public interface ItestGnrcAltParamOutp
{
  RefGnrcAltParamOutp<AltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; }
}

public interface ItestRefGnrcAltParamOutp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcAltParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
