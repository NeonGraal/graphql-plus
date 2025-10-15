//HintName: test_generic-parent-param+Input_Intf.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public interface ItestGnrcPrntParamInp
  : ItestRefGnrcPrntParamInp
{
}

public interface ItestRefGnrcPrntParamInp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcPrntParamInp
{
  Number alt { get; }
  String AsString { get; }
}
