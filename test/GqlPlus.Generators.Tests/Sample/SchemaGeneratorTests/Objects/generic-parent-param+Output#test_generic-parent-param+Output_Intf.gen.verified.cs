//HintName: test_generic-parent-param+Output_Intf.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp
{
}

public interface ItestRefGnrcPrntParamOutp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcPrntParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
