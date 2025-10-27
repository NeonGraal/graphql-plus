//HintName: test_generic-alt-param+Input_Intf.gen.cs
// Generated from generic-alt-param+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public interface ItestGnrcAltParamInp
{
  RefGnrcAltParamInp<AltGnrcAltParamInp> AsRefGnrcAltParamInp { get; }
}

public interface ItestRefGnrcAltParamInp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcAltParamInp
{
  Number alt { get; }
  String AsString { get; }
}
