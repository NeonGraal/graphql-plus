//HintName: test_generic-parent-param-parent+Output_Intf.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public interface ItestGnrcPrntParamPrntOutp
  : ItestRefGnrcPrntParamPrntOutp
{
}

public interface ItestRefGnrcPrntParamPrntOutp<Tref>
  : Itestref
{
}

public interface ItestAltGnrcPrntParamPrntOutp
{
  Number alt { get; }
  String AsString { get; }
}
