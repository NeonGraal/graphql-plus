//HintName: test_generic-parent-dual-parent+Output_Intf.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public interface ItestGnrcPrntDualPrntOutp
  : ItestRefGnrcPrntDualPrntOutp
{
}

public interface ItestRefGnrcPrntDualPrntOutp<Tref>
  : Itestref
{
}

public interface ItestAltGnrcPrntDualPrntOutp
{
  Number alt { get; }
  String AsString { get; }
}
