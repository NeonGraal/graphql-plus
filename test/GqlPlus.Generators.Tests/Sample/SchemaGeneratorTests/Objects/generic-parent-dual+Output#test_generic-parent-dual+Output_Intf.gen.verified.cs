//HintName: test_generic-parent-dual+Output_Intf.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp
{
}

public interface ItestRefGnrcPrntDualOutp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcPrntDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
